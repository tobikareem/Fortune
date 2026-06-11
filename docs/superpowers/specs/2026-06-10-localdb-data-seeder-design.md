# LocalDB Data Seeder — Design

**Date:** 2026-06-10
**Status:** Approved (pending spec review)
**Author:** Tobi Kareem (with Claude)

## Problem

The repo-root `Data/` folder contains a table-by-table CSV export of the Fortune
production dataset (the live data that resides in the Azure SQL `fortuneweb`
database). The goal is to **refresh the local `(localdb)\MSSQLLocalDB` `FortuneDb`
database** from a clean slate and load this exported data into it, so local
development runs against realistic data. The load must be done **through EF Core**.

The exports preserve explicit primary keys and the foreign-key relationships
between tables, so a naive `AddRange`/`SaveChanges` will not work — the seeder
must preserve identity-column values and insert in dependency order.

## Goals

- Drop and recreate the local `FortuneDb` deterministically.
- Recreate the schema from the existing EF Core migrations (Identity tables +
  `fort` schema tables).
- Load all 9 exported CSVs, preserving primary keys and foreign keys.
- Stay within the EF Core / C# world (no hand-written bulk SQL for the data load).
- Be safe: refuse to run against anything that is not LocalDB unless forced.

## Non-Goals (YAGNI)

- No production / Azure SQL target. LocalDB only.
- No incremental sync / upsert / merge — this is a full wipe-and-reload.
- No UI.
- Not wired into the web app's startup path.

## Source Data

Location: repo-root `Data/`. Nine CSVs, each a 1:1 export of a database table.

| CSV | Table | Schema | Key | Identity insert? |
|-----|-------|--------|-----|------------------|
| `AspNetUsers.csv` | AspNetUsers | default | `Id` (GUID string) | No |
| `AspNetUserClaims.csv` | AspNetUserClaims | default | `Id` (int) | **Yes** |
| `AspNetUserLogins.csv` | AspNetUserLogins | default | (`LoginProvider`,`ProviderKey`) | No |
| `AspNetUserTokens.csv` | AspNetUserTokens | default | (`UserId`,`LoginProvider`,`Name`) | No |
| `Category.csv` | fort.Category | fort | `Id` (int) | **Yes** |
| `Post.csv` | fort.Post | fort | `Id` (int) | **Yes** |
| `PostCategory.csv` | fort.PostCategory | fort | `Id` (int) | **Yes** |
| `UserPost.csv` | fort.UserPost | fort | `Id` (int) | **Yes** |
| `UserDetails.csv` | fort.UserDetails | fort | `Id` (int) | **Yes** |

Not present in the export (tables exist but were empty): `fort.Comment`,
`fort.Suggestions`, and the Identity role tables (`AspNetRoles`,
`AspNetUserRoles`, `AspNetRoleClaims`). The seeder simply skips absent CSVs.

### Sensitivity

This data contains real user PII, ASP.NET Identity password hashes, OAuth login
provider keys, and at least one live Spotify access token. **`Data/` must be in
`.gitignore`** and must never be committed. This precondition is folded into the
implementation plan.

## Key Technical Findings (verified against the code)

1. **TPH discriminator.** The model maps `ApplicationUser : IdentityUser` as a
   Table-Per-Hierarchy derived type. `AspNetUsers` has a `Discriminator` column;
   `IdentityUser` → `"IdentityUser"`, `ApplicationUser` → `"ApplicationUser"`.
   Every domain navigation (`Post.User`, `UserDetail.User`, `UserPost.User`,
   `Comment.User`) points at `ApplicationUser`. The export's `Discriminator`
   column is `"ApplicationUser"`. Therefore users must be inserted **as
   `ApplicationUser`** (via `context.Set<ApplicationUser>()`) so EF writes the
   correct discriminator and FKs resolve.

2. **Explicit identity keys.** Six tables use int identity PKs whose values must
   be preserved (see table above). EF Core will not emit an explicit value for a
   store-generated key unless the key is mapped `ValueGeneratedNever()`. So a
   seeding-specific context is required.

3. **CSV content is not comma-safe by naive parsing.** `Post.Content` holds HTML
   that contains commas, quotes, and possibly newlines. RFC-4180-aware parsing
   (CsvHelper) is mandatory; string splitting would corrupt rows.

4. **Column/property name mismatch.** `Category.csv` has a `Category` column that
   maps to entity property `Category1` (`.HasColumnName("Category")`). A
   CsvHelper `ClassMap` handles this and any other mismatches.

## Architecture

New console project: **`src/Tools/DataSeeder`** (added to `Fortune.sln`),
referencing the **Data** and **Core** projects.

```
src/Tools/DataSeeder/
  DataSeeder.csproj          // net9.0 console; refs Data + Core
  Program.cs                 // orchestration + CLI args
  SeederDbContext.cs         // FortuneDbContext subclass; ValueGeneratedNever on int PKs
  IdentityInsertScope.cs     // IDisposable wrapping SET IDENTITY_INSERT ON/OFF in a tx
  CsvMaps/                   // one CsvHelper ClassMap per table
  appsettings.json           // local connection string (gitignored)
```

Packages: `CsvHelper`, `Microsoft.EntityFrameworkCore.SqlServer`,
`Microsoft.EntityFrameworkCore.Design`, `Microsoft.Extensions.Configuration.Json`,
`Microsoft.Extensions.Configuration.CommandLine`.

### Components

- **`Program.cs`** — parses args, resolves connection string + data path, runs the
  refresh + load flow, prints results, sets exit code.
- **`SeederDbContext : FortuneDbContext`** — overrides `OnModelCreating` to mark
  the six int PKs `ValueGeneratedNever()`. The production `FortuneDbContext` is
  left untouched. Constructed with `DbContextOptions` pointing at LocalDB.
- **`IdentityInsertScope`** — `using` helper that opens a transaction and issues
  `SET IDENTITY_INSERT <table> ON`, then `OFF` + commit on dispose. Used only for
  the six identity-insert tables.
- **`CsvMaps/*`** — CsvHelper `ClassMap<T>` per table: column→property mapping,
  empty-string→`null` for nullable members, `TRUE/FALSE`→`bool`, ISO-8601→
  `DateTime`/`DateTimeOffset`.

## Data Flow

1. **Resolve config** — connection string (default
   `Server=(localdb)\MSSQLLocalDB;Database=FortuneDb;Trusted_Connection=True;`),
   data path (default repo-root `Data/`), and flags.
2. **Safety guard** — if the connection string does not target LocalDB, abort
   unless `--force` is supplied.
3. **Drop** — `context.Database.EnsureDeleted()`.
4. **Recreate schema** — `context.Database.Migrate()` (applies existing
   migrations → Identity + `fort` schema).
5. **Load in FK-dependency order:**
   1. `AspNetUsers` (as `ApplicationUser`)
   2. `Category`
   3. `Post`
   4. `AspNetUserClaims`, `AspNetUserLogins`, `AspNetUserTokens`, `UserDetails`
   5. `PostCategory`
   6. `UserPost`
   - Each int-PK table's insert is wrapped in an `IdentityInsertScope`.
6. **Verify** — re-query each table's row count and print `expected vs actual`.
7. **Exit** — `0` on success; non-zero with the offending table/row on failure.

## Configuration & Usage

```bash
dotnet run --project src/Tools/DataSeeder
# overrides:
dotnet run --project src/Tools/DataSeeder -- --connection "Server=...;Database=FortuneDb;..."
dotnet run --project src/Tools/DataSeeder -- --data-path "C:\path\to\Data"
dotnet run --project src/Tools/DataSeeder -- --force   # bypass LocalDB-only guard
```

Connection resolution order: `--connection` arg → seeder `appsettings.json`
`ConnectionStrings:DefaultConnection` → built-in LocalDB default.

## Error Handling

- Whole run wrapped in try/catch with per-table progress logging.
- A failed table aborts the run, reports the table and (where possible) the row,
  and returns a non-zero exit code.
- Missing CSV for a known table → logged as skipped, not fatal.
- LocalDB-only guard prevents accidental writes to a remote/production server.

## Testing / Verification

There is no test project in the solution, and adding one is out of scope. The
seeder self-verifies via the post-load row-count comparison (§Data Flow step 6).
Manual acceptance: run the tool, confirm `expected == actual` for every table,
then launch the web app in Development and confirm posts/users render.

## Open Risks

- If the CSVs were not exported with RFC-4180 quoting, multi-line/HTML content
  rows could be malformed. Mitigation: CsvHelper's `BadDataFound` /
  `MissingFieldFound` hooks will surface this loudly rather than silently
  corrupting data; first run validates row counts against the CSV line counts.
- `EnsureDeleted` followed by `Migrate` requires the LocalDB instance to be
  available; the tool reports a clear error if the instance can't be reached.
