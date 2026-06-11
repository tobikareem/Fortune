# LocalDB Data Seeder Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Build an EF Core console tool (`src/Tools/DataSeeder`) that drops and recreates the local `(localdb)\MSSQLLocalDB` `FortuneDb`, applies migrations, and loads the repo-root `Data/` CSV export while preserving primary/foreign keys.

**Architecture:** A standalone .NET 9 console app referencing the existing **Data** project. A `SeederDbContext : FortuneDbContext` marks the six integer identity PKs `ValueGeneratedNever()` so explicit key values are inserted; each such table's load is wrapped in a `SET IDENTITY_INSERT` transaction. CSVs are parsed with CsvHelper (RFC-4180 safe) and loaded in foreign-key dependency order, with users inserted as the TPH `ApplicationUser` type.

**Tech Stack:** .NET 9, EF Core 9 (SqlServer), CsvHelper, LocalDB, Microsoft.Extensions.Configuration.Json.

---

## Testing approach (read first)

The solution has **no test project**, and the design spec explicitly scopes adding one out. A CSV→DB seeder's real test is an integration run against LocalDB. Therefore this plan deviates from strict unit-TDD: **the verification gate for each task is `dotnet build` success, and the final acceptance gate is a full `dotnet run` that prints `expected vs actual` row counts per table.** This is intentional and matches the spec's self-verification design.

## File Structure

```
.gitignore                                  // MODIFY: ignore Data/ and the seeder's appsettings.json
Fortune.sln                                 // MODIFY: add DataSeeder project
src/Tools/DataSeeder/
  DataSeeder.csproj                         // CREATE: console project, refs Data
  appsettings.json                          // CREATE (gitignored): local connection string
  SeederDbContext.cs                        // CREATE: FortuneDbContext subclass, ValueGeneratedNever
  CsvLoader.cs                              // CREATE: lenient CsvHelper read helper + map registration
  CsvMaps.cs                                // CREATE: ClassMaps for the 6 mapped entity types
  Seeder.cs                                 // CREATE: drop/migrate/load/verify orchestration
  Program.cs                                // CREATE: arg parsing, config, LocalDB guard, entry point
```

Responsibilities are split so each file holds one concern: schema/key config (`SeederDbContext`), parsing (`CsvLoader` + `CsvMaps`), load+verify logic (`Seeder`), and wiring/CLI (`Program`).

---

### Task 1: Scaffold the project, wire the solution, protect the data

**Files:**
- Create: `src/Tools/DataSeeder/DataSeeder.csproj`
- Create: `src/Tools/DataSeeder/appsettings.json`
- Create: `src/Tools/DataSeeder/Program.cs` (temporary stub, replaced in Task 5)
- Modify: `.gitignore`
- Modify: `Fortune.sln`

- [ ] **Step 1: Create the project file**

Create `src/Tools/DataSeeder/DataSeeder.csproj`:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <RootNamespace>DataSeeder</RootNamespace>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="CsvHelper" Version="33.0.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="9.0.0" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="9.0.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\..\Data\Data.csproj" />
  </ItemGroup>

  <ItemGroup>
    <None Update="appsettings.json">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
  </ItemGroup>

</Project>
```

- [ ] **Step 2: Create the seeder's local config**

Create `src/Tools/DataSeeder/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=FortuneDb;Trusted_Connection=True;MultipleActiveResultSets=true;"
  }
}
```

- [ ] **Step 3: Create a temporary Program.cs stub**

Create `src/Tools/DataSeeder/Program.cs` (replaced in Task 5; this only lets the project build now):

```csharp
Console.WriteLine("DataSeeder scaffold — implemented in later tasks.");
```

- [ ] **Step 4: Protect the data and local config in git**

Add these lines to `.gitignore` (append at end):

```gitignore
# Production data export — real PII/secrets, never commit
/Data/

# Seeder local connection config
src/Tools/DataSeeder/appsettings.json
```

- [ ] **Step 5: Add the project to the solution**

Run:

```bash
dotnet sln Fortune.sln add src/Tools/DataSeeder/DataSeeder.csproj
```

Expected: `Project ... added to the solution.`

- [ ] **Step 6: Verify it builds**

Run:

```bash
dotnet build src/Tools/DataSeeder/DataSeeder.csproj
```

Expected: `Build succeeded.` with 0 errors.

- [ ] **Step 7: Verify the data is now ignored**

Run:

```bash
git status --short
```

Expected: `Data/` no longer appears as untracked; `src/Tools/DataSeeder/` appears (minus `appsettings.json`).

- [ ] **Step 8: Commit**

```bash
git add .gitignore Fortune.sln src/Tools/DataSeeder/DataSeeder.csproj src/Tools/DataSeeder/Program.cs
git commit -m "Scaffold DataSeeder project and gitignore data export"
```

---

### Task 2: SeederDbContext with explicit-key configuration

**Files:**
- Create: `src/Tools/DataSeeder/SeederDbContext.cs`

- [ ] **Step 1: Implement the context**

Create `src/Tools/DataSeeder/SeederDbContext.cs`. It subclasses the production `FortuneDbContext`, configures the connection in `OnConfiguring` (pointing migrations at the `Data` assembly), and marks the six integer PKs as not store-generated so EF emits explicit `Id` values:

```csharp
using Data.Context;
using Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataSeeder;

public sealed class SeederDbContext : FortuneDbContext
{
    private readonly string _connectionString;

    public SeederDbContext(string connectionString) => _connectionString = connectionString;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Migrations live in the Data assembly, not this console app.
            optionsBuilder.UseSqlServer(_connectionString, sql => sql.MigrationsAssembly("Data"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Preserve the exact Id values from the export. Combined with
        // SET IDENTITY_INSERT (see Seeder.cs), EF will send explicit keys.
        modelBuilder.Entity<Category>().Property(e => e.Id).ValueGeneratedNever();
        modelBuilder.Entity<Post>().Property(e => e.Id).ValueGeneratedNever();
        modelBuilder.Entity<PostCategory>().Property(e => e.Id).ValueGeneratedNever();
        modelBuilder.Entity<UserPost>().Property(e => e.Id).ValueGeneratedNever();
        modelBuilder.Entity<UserDetail>().Property(e => e.Id).ValueGeneratedNever();
        modelBuilder.Entity<IdentityUserClaim<string>>().Property(e => e.Id).ValueGeneratedNever();
    }
}
```

- [ ] **Step 2: Verify it builds**

Run:

```bash
dotnet build src/Tools/DataSeeder/DataSeeder.csproj
```

Expected: `Build succeeded.` with 0 errors.

- [ ] **Step 3: Commit**

```bash
git add src/Tools/DataSeeder/SeederDbContext.cs
git commit -m "Add SeederDbContext with explicit-key configuration"
```

---

### Task 3: CSV maps and lenient loader

**Files:**
- Create: `src/Tools/DataSeeder/CsvMaps.cs`
- Create: `src/Tools/DataSeeder/CsvLoader.cs`

- [ ] **Step 1: Implement the ClassMaps**

Create `src/Tools/DataSeeder/CsvMaps.cs`. Explicit maps avoid CsvHelper auto-mapping the navigation/collection properties on these entities. Column names match the CSV headers exactly; note `Category` → `Category1` and the `ProfileImage` base64/empty handling:

```csharp
using System.Globalization;
using CsvHelper.Configuration;
using Data.Entity;

namespace DataSeeder;

public sealed class CategoryMap : ClassMap<Category>
{
    public CategoryMap()
    {
        Map(m => m.Id).Name("Id");
        Map(m => m.CreatedOn).Name("CreatedOn");
        Map(m => m.ModifiedOn).Name("ModifiedOn");
        Map(m => m.ModifiedBy).Name("ModifiedBy");
        Map(m => m.CreatedBy).Name("CreatedBy");
        Map(m => m.Enabled).Name("Enabled");
        Map(m => m.Category1).Name("Category");
        Map(m => m.Description).Name("Description");
        Map(m => m.PostCategories).Ignore();
        Map(m => m.Posts).Ignore();
    }
}

public sealed class PostMap : ClassMap<Post>
{
    public PostMap()
    {
        Map(m => m.Id).Name("Id");
        Map(m => m.CreatedOn).Name("CreatedOn");
        Map(m => m.ModifiedOn).Name("ModifiedOn");
        Map(m => m.ModifiedBy).Name("ModifiedBy");
        Map(m => m.CreatedBy).Name("CreatedBy");
        Map(m => m.Enabled).Name("Enabled");
        Map(m => m.Title).Name("Title");
        Map(m => m.Description).Name("Description");
        Map(m => m.Content).Name("Content");
        Map(m => m.UserId).Name("UserId");
        Map(m => m.CategoryId).Name("CategoryId");
        Map(m => m.IsPublished).Name("IsPublished");
        Map(m => m.IsReviewPost).Name("IsReviewPost");
        Map(m => m.Category).Ignore();
        Map(m => m.User).Ignore();
        Map(m => m.Comments).Ignore();
        Map(m => m.PostCategories).Ignore();
        Map(m => m.UserPosts).Ignore();
    }
}

public sealed class PostCategoryMap : ClassMap<PostCategory>
{
    public PostCategoryMap()
    {
        Map(m => m.Id).Name("Id");
        Map(m => m.PostId).Name("PostId");
        Map(m => m.CategoryId).Name("CategoryId");
        Map(m => m.Category).Ignore();
        Map(m => m.Post).Ignore();
    }
}

public sealed class UserPostMap : ClassMap<UserPost>
{
    public UserPostMap()
    {
        Map(m => m.Id).Name("Id");
        Map(m => m.PostId).Name("PostId");
        Map(m => m.UserId).Name("UserId");
        Map(m => m.Post).Ignore();
        Map(m => m.User).Ignore();
    }
}

public sealed class UserDetailMap : ClassMap<UserDetail>
{
    public UserDetailMap()
    {
        Map(m => m.Id).Name("Id");
        Map(m => m.Title).Name("Title");
        Map(m => m.Company).Name("Company");
        Map(m => m.Birthday).Name("Birthday");
        Map(m => m.WebsiteUrl).Name("WebsiteUrl");
        Map(m => m.YoutubeLink).Name("YoutubeLink");
        Map(m => m.FacebookLink).Name("FacebookLink");
        Map(m => m.TwitterLink).Name("TwitterLink");
        Map(m => m.InstagramLink).Name("InstagramLink");
        Map(m => m.LinkedInLink).Name("LinkedInLink");
        Map(m => m.UserId).Name("UserId");
        Map(m => m.CreatedOn).Name("CreatedOn");
        Map(m => m.ModifiedOn).Name("ModifiedOn");
        Map(m => m.ModifiedBy).Name("ModifiedBy");
        Map(m => m.CreatedBy).Name("CreatedBy");
        Map(m => m.Enabled).Name("Enabled");
        Map(m => m.DriveFileId).Name("DriveFileId");
        Map(m => m.IsSubscribed).Name("IsSubscribed");
        Map(m => m.Location).Name("Location");
        Map(m => m.ProfileImage).Convert(args =>
        {
            var raw = args.Row.GetField("ProfileImage");
            return string.IsNullOrWhiteSpace(raw) ? null : Convert.FromBase64String(raw);
        });
        Map(m => m.User).Ignore();
    }
}

public sealed class ApplicationUserMap : ClassMap<ApplicationUser>
{
    public ApplicationUserMap()
    {
        Map(m => m.Id).Name("Id");
        Map(m => m.UserName).Name("UserName");
        Map(m => m.NormalizedUserName).Name("NormalizedUserName");
        Map(m => m.Email).Name("Email");
        Map(m => m.NormalizedEmail).Name("NormalizedEmail");
        Map(m => m.EmailConfirmed).Name("EmailConfirmed");
        Map(m => m.PasswordHash).Name("PasswordHash");
        Map(m => m.SecurityStamp).Name("SecurityStamp");
        Map(m => m.ConcurrencyStamp).Name("ConcurrencyStamp");
        Map(m => m.PhoneNumber).Name("PhoneNumber");
        Map(m => m.PhoneNumberConfirmed).Name("PhoneNumberConfirmed");
        Map(m => m.TwoFactorEnabled).Name("TwoFactorEnabled");
        Map(m => m.LockoutEnd).Name("LockoutEnd");
        Map(m => m.LockoutEnabled).Name("LockoutEnabled");
        Map(m => m.AccessFailedCount).Name("AccessFailedCount");
        Map(m => m.Posts).Ignore();
        Map(m => m.UserPosts).Ignore();
        Map(m => m.UserDetails).Ignore();
    }
}
```

- [ ] **Step 2: Implement the loader**

Create `src/Tools/DataSeeder/CsvLoader.cs`. It reads a typed list from a CSV file using a lenient configuration (extra columns such as `Discriminator` ignored; missing optional columns tolerated) and registers the maps from Step 1. The three Identity child types (`IdentityUserClaim`, `IdentityUserLogin`, `IdentityUserToken`) have no navigation properties and are auto-mapped by header:

```csharp
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace DataSeeder;

public static class CsvLoader
{
    private static CsvConfiguration BuildConfig() => new(CultureInfo.InvariantCulture)
    {
        // The export includes columns not on the entity (e.g. Discriminator);
        // and some entities have properties absent from the CSV. Be lenient.
        HeaderValidated = null,
        MissingFieldFound = null,
    };

    public static List<T> Read<T>(string path)
    {
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, BuildConfig());
        RegisterMaps(csv.Context);
        return csv.GetRecords<T>().ToList();
    }

    private static void RegisterMaps(CsvHelper.CsvContext ctx)
    {
        ctx.RegisterClassMap<CategoryMap>();
        ctx.RegisterClassMap<PostMap>();
        ctx.RegisterClassMap<PostCategoryMap>();
        ctx.RegisterClassMap<UserPostMap>();
        ctx.RegisterClassMap<UserDetailMap>();
        ctx.RegisterClassMap<ApplicationUserMap>();
    }
}
```

- [ ] **Step 3: Verify it builds**

Run:

```bash
dotnet build src/Tools/DataSeeder/DataSeeder.csproj
```

Expected: `Build succeeded.` with 0 errors.

- [ ] **Step 4: Commit**

```bash
git add src/Tools/DataSeeder/CsvMaps.cs src/Tools/DataSeeder/CsvLoader.cs
git commit -m "Add CsvHelper maps and lenient CSV loader"
```

---

### Task 4: Seeder orchestration (drop, migrate, load, verify)

**Files:**
- Create: `src/Tools/DataSeeder/Seeder.cs`

- [ ] **Step 1: Implement the seeder**

Create `src/Tools/DataSeeder/Seeder.cs`. It drops and recreates the schema, loads every CSV in FK-dependency order (users as `ApplicationUser`; int-PK tables wrapped in `SET IDENTITY_INSERT`), then verifies row counts. Tables without an int identity (`AspNetUsers`, `AspNetUserLogins`, `AspNetUserTokens`) are inserted plainly:

```csharp
using Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataSeeder;

public sealed class Seeder
{
    private readonly SeederDbContext _ctx;
    private readonly string _dataPath;

    public Seeder(SeederDbContext ctx, string dataPath)
    {
        _ctx = ctx;
        _dataPath = dataPath;
    }

    public void Run()
    {
        Console.WriteLine("Dropping local database...");
        _ctx.Database.EnsureDeleted();

        Console.WriteLine("Applying migrations...");
        _ctx.Database.Migrate();

        Console.WriteLine("Loading data...");

        // 1. Users first (GUID PK, inserted as the ApplicationUser TPH type).
        var users = CsvLoader.Read<ApplicationUser>(Path("AspNetUsers.csv"));
        _ctx.Set<ApplicationUser>().AddRange(users);
        _ctx.SaveChanges();
        Console.WriteLine($"  AspNetUsers: {users.Count}");

        // 2. Category, 3. Post (int identity PK).
        SeedWithIdentityInsert("fort.Category", CsvLoader.Read<Category>(Path("Category.csv")));
        SeedWithIdentityInsert("fort.Post", CsvLoader.Read<Post>(Path("Post.csv")));

        // 4. User-dependent tables.
        SeedWithIdentityInsert("AspNetUserClaims",
            CsvLoader.Read<IdentityUserClaim<string>>(Path("AspNetUserClaims.csv")));

        var logins = CsvLoader.Read<IdentityUserLogin<string>>(Path("AspNetUserLogins.csv"));
        _ctx.Set<IdentityUserLogin<string>>().AddRange(logins);
        _ctx.SaveChanges();
        Console.WriteLine($"  AspNetUserLogins: {logins.Count}");

        var tokens = CsvLoader.Read<IdentityUserToken<string>>(Path("AspNetUserTokens.csv"));
        _ctx.Set<IdentityUserToken<string>>().AddRange(tokens);
        _ctx.SaveChanges();
        Console.WriteLine($"  AspNetUserTokens: {tokens.Count}");

        SeedWithIdentityInsert("fort.UserDetails", CsvLoader.Read<UserDetail>(Path("UserDetails.csv")));

        // 5. Join tables (depend on Post + Category / Post + User).
        SeedWithIdentityInsert("fort.PostCategory", CsvLoader.Read<PostCategory>(Path("PostCategory.csv")));
        SeedWithIdentityInsert("fort.UserPost", CsvLoader.Read<UserPost>(Path("UserPost.csv")));

        Console.WriteLine("Load complete.");
    }

    private void SeedWithIdentityInsert<T>(string table, List<T> rows) where T : class
    {
        using var tx = _ctx.Database.BeginTransaction();
        _ctx.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {table} ON");
        _ctx.Set<T>().AddRange(rows);
        _ctx.SaveChanges();
        _ctx.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {table} OFF");
        tx.Commit();
        Console.WriteLine($"  {table}: {rows.Count}");
    }

    private string Path(string file) => System.IO.Path.Combine(_dataPath, file);
}
```

- [ ] **Step 2: Verify it builds**

Run:

```bash
dotnet build src/Tools/DataSeeder/DataSeeder.csproj
```

Expected: `Build succeeded.` with 0 errors.

- [ ] **Step 3: Commit**

```bash
git add src/Tools/DataSeeder/Seeder.cs
git commit -m "Add seeder orchestration with identity-insert and FK ordering"
```

---

### Task 5: Program entry point — config, CLI args, LocalDB guard

**Files:**
- Modify: `src/Tools/DataSeeder/Program.cs` (replace the Task 1 stub)

- [ ] **Step 1: Implement the entry point**

Replace the entire contents of `src/Tools/DataSeeder/Program.cs`:

```csharp
using DataSeeder;
using Microsoft.Extensions.Configuration;

// --- Parse args: --connection, --data-path, --force ---
string? connOverride = GetArg(args, "--connection");
string? dataPathOverride = GetArg(args, "--data-path");
bool force = args.Contains("--force", StringComparer.OrdinalIgnoreCase);

// --- Resolve connection string: arg > appsettings.json > built-in default ---
var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: true)
    .Build();

string connectionString = connOverride
    ?? config.GetConnectionString("DefaultConnection")
    ?? @"Server=(localdb)\MSSQLLocalDB;Database=FortuneDb;Trusted_Connection=True;MultipleActiveResultSets=true;";

// --- LocalDB safety guard ---
if (!connectionString.Contains("localdb", StringComparison.OrdinalIgnoreCase) && !force)
{
    Console.Error.WriteLine(
        "Refusing to run: connection string does not target LocalDB. " +
        "Pass --force to override (this WILL drop and overwrite the target database).");
    return 1;
}

// --- Resolve the Data/ folder: arg > repo-root Data/ relative to this exe ---
string dataPath = dataPathOverride
    ?? Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "..", "Data"));

if (!Directory.Exists(dataPath))
{
    Console.Error.WriteLine($"Data folder not found: {dataPath}. Pass --data-path to specify it.");
    return 1;
}

Console.WriteLine($"Target:    {connectionString}");
Console.WriteLine($"Data path: {dataPath}");

try
{
    using var ctx = new SeederDbContext(connectionString);
    var seeder = new Seeder(ctx, dataPath);
    seeder.Run();
    Verify(ctx, dataPath);
    return 0;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"SEED FAILED: {ex.Message}");
    Console.Error.WriteLine(ex.StackTrace);
    return 1;
}

static string? GetArg(string[] args, string name)
{
    var i = Array.FindIndex(args, a => string.Equals(a, name, StringComparison.OrdinalIgnoreCase));
    return i >= 0 && i + 1 < args.Length ? args[i + 1] : null;
}

// Compare DB row counts against CSV row counts (CSV lines minus header).
static void Verify(SeederDbContext ctx, string dataPath)
{
    Console.WriteLine("\nVerification (expected vs actual):");
    var checks = new (string Csv, string Table)[]
    {
        ("AspNetUsers.csv", "AspNetUsers"),
        ("AspNetUserClaims.csv", "AspNetUserClaims"),
        ("AspNetUserLogins.csv", "AspNetUserLogins"),
        ("AspNetUserTokens.csv", "AspNetUserTokens"),
        ("Category.csv", "fort.Category"),
        ("Post.csv", "fort.Post"),
        ("PostCategory.csv", "fort.PostCategory"),
        ("UserPost.csv", "fort.UserPost"),
        ("UserDetails.csv", "fort.UserDetails"),
    };

    foreach (var (csv, table) in checks)
    {
        var path = Path.Combine(dataPath, csv);
        if (!File.Exists(path)) { Console.WriteLine($"  {table}: CSV missing, skipped"); continue; }
        int expected = Math.Max(0, File.ReadAllLines(path).Length - 1);
        int actual = ctx.Database
            .SqlQueryRaw<int>($"SELECT COUNT(*) AS Value FROM {table}")
            .AsEnumerable()
            .First();
        var flag = expected == actual ? "OK" : "MISMATCH";
        Console.WriteLine($"  {table}: {expected} vs {actual}  [{flag}]");
    }
}
```

Note on `--data-path` default: the six `..` segments climb from
`src/Tools/DataSeeder/bin/Debug/net9.0/` back to the repo root. If your build
output differs, pass `--data-path` explicitly.

- [ ] **Step 2: Verify it builds**

Run:

```bash
dotnet build src/Tools/DataSeeder/DataSeeder.csproj
```

Expected: `Build succeeded.` with 0 errors.

- [ ] **Step 3: Commit**

```bash
git add src/Tools/DataSeeder/Program.cs
git commit -m "Add DataSeeder entry point with config, CLI args, and LocalDB guard"
```

---

### Task 6: Full run and acceptance verification

**Files:** none (integration run).

- [ ] **Step 1: Run the seeder**

Run from repo root:

```bash
dotnet run --project src/Tools/DataSeeder
```

Expected output (counts derived from the export; exact numbers may vary slightly):
```
Target:    Server=(localdb)\MSSQLLocalDB;Database=FortuneDb;...
Data path: ...\Fortune\Data
Dropping local database...
Applying migrations...
Loading data...
  AspNetUsers: 95
  fort.Category: 5
  fort.Post: 77
  AspNetUserClaims: 283
  AspNetUserLogins: 4
  AspNetUserTokens: 2
  fort.UserDetails: 9
  fort.PostCategory: 8
  fort.UserPost: 8
Load complete.

Verification (expected vs actual):
  AspNetUsers: 95 vs 95  [OK]
  ...
  fort.UserPost: 8 vs 8  [OK]
```

- [ ] **Step 2: Confirm every line reads `[OK]`**

If any line reads `[MISMATCH]`, stop and investigate that table's CSV (likely an RFC-4180 quoting issue in `Post.Content` or a FK referencing a user absent from `AspNetUsers.csv`). Re-run after fixing — the tool is idempotent because it drops first.

- [ ] **Step 3: Smoke-test the app against the seeded data**

Run:

```bash
dotnet run --project src/Web/Web.csproj
```

Then browse to `https://localhost:7213` and confirm posts and user content render. Stop the app with Ctrl+C.

- [ ] **Step 4: Final confirmation**

Confirm `git status` shows no stray tracked changes from the run (the seeded DB and `Data/` are untracked/ignored). No commit needed for this task.

---

## Self-Review notes

- **Spec coverage:** drop & recreate (Task 4 §EnsureDeleted/Migrate), all 9 CSVs in FK order (Task 4), `ApplicationUser` discriminator (Task 4 §users + ApplicationUserMap), identity insert for the 6 int-PK tables (SeederDbContext + `SeedWithIdentityInsert`), CsvHelper RFC-4180 parsing + `Category1`/`ProfileImage` edge cases (Task 3), LocalDB-only guard with `--force` (Task 5), `--connection`/`--data-path` overrides (Task 5), row-count verification (Task 5 `Verify`), `Data/` gitignored (Task 1). All spec sections map to a task.
- **Type consistency:** `SeederDbContext`, `CsvLoader.Read<T>`, `Seeder.SeedWithIdentityInsert<T>`, and `ApplicationUserMap` names are used identically across tasks. Identity-insert table set (Category, Post, PostCategory, UserPost, UserDetails, AspNetUserClaims) matches between `SeederDbContext.OnModelCreating` and the `SeedWithIdentityInsert` calls.
- **Deviation (documented):** no unit-test project per spec scope; build success + full-run row-count verification are the gates.
