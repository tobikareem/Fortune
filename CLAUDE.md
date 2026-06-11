# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project overview

Fortune is an ASP.NET Core **Razor Pages** personal website/blog on **.NET 9**, with ASP.NET Identity, external OAuth providers (Facebook, Twitter, Spotify, Google), EF Core + SQL Server, NLog, and Azure App Configuration / App Services integration. The solution file is `Fortune.sln`.

## Common commands

Run from the repo root unless noted. Use `dotnet` CLI (Visual Studio also works; there is no npm/yarn pipeline).

```bash
# Restore & build the whole solution
dotnet restore Fortune.sln
dotnet build Fortune.sln

# Run the web app (listens on https://localhost:7213 / http://localhost:5213 in Development)
dotnet run --project src/Web/Web.csproj

# Publish for deployment
dotnet publish src/Web/Web.csproj -c Release

# EF Core migrations — DbContext lives in src/Data, tools are referenced from src/Web,
# so pass both --project (where migrations are created) and --startup-project (config/DI).
dotnet ef migrations add <Name> --project src/Data --startup-project src/Web
dotnet ef database update          --project src/Data --startup-project src/Web

# Refresh the local LocalDB FortuneDb from the Data/ CSV export (drops & rebuilds,
# preserves PKs/FKs). Guards against non-LocalDB targets unless --force is passed.
dotnet run --project src/Tools/DataSeeder
```

There is currently **no test project** in the solution — don't invent a `dotnet test` workflow; add a test project first if tests are needed. `.github/workflows/` exists but is empty (no CI pipeline configured in-repo).

## Solution layout

Four core projects under `src/`, all targeting `net9.0` with nullable + implicit usings enabled, plus a dev-only console tool under `src/Tools/`. Dependency direction is strictly one-way:

- **Core** — POCO models (`Core.Models`), options/config classes (`Core.Configuration`), string/enum constants (`Core.Constants`), email HTML templates. No project references. Depends on MailKit + Newtonsoft.Json.
- **Data** — EF Core layer. Entities (`Data.Entity`), `FortuneDbContext`, and migrations. References Core. Uses `Microsoft.AspNetCore.Identity.EntityFrameworkCore` and SQL Server provider.
- **Shared** — Business services (`Shared.Services`) and repositories (`Shared.Repository`) behind interfaces in `Shared.Interfaces.Services` / `Shared.Interfaces.Repository`. References Core and Data. Also wraps third-party SDKs (SpotifyAPI.Web, TweetinviAPI, Google APIs, SendGrid, CaptainOath.DataStore).
- **Web** — Razor Pages app (`src/Web/Pages`), startup, custom authorization handlers, filters. References Core, Data, and Shared. Contains `Program.cs`, `appsettings*.json`, `nlog.config`.
- **Tools/DataSeeder** (`src/Tools/DataSeeder`) — dev-only console tool that refreshes the local LocalDB `FortuneDb` from the `Data/` CSV export. References Data. Uses CsvHelper. Not part of the runtime app; see the seeder command above and the gotchas below for the EF migration caveats it works around.

Root-level `Flight/` is an orphaned sibling (only `bin/obj`) and is **not** in the solution — ignore it unless explicitly asked.

## Architectural entry points

- **`src/Web/Program.cs`** is intentionally tiny. All DI and middleware wiring lives in two extension methods:
  - **`DependentServiceCollection.ConfigureCustomServices`** (`src/Web/Extensions/DependentServiceCollection.cs`) — reads configuration, binds every `Configure<T>(...)` options section, picks the connection string, registers Identity + authorization policies + external auth providers, and registers every service/repository. This is the first place to look when adding a new option section, policy, or DI registration.
  - **`DependentAppBuilder.UseCustomServiceBuilder`** (`src/Web/Extensions/DependentAppBuilder.cs`) — builds the HTTP pipeline, maps Razor Pages, `/health`, and status-code re-execution to `/StatusPage/{0}`.

## Configuration

- Options section names are **centralized as constants** on `Core.Configuration.ConfigAppSetting` (e.g. `ConfigAppSetting.SpotifyOptions = "Authentications_Spotify"`). When adding a new options type, add a matching `public const string XxxOptions` there and a `services.Configure<T>(config.GetSection(ConfigAppSetting.XxxOptions))` call in `ConfigureCustomServices` rather than hard-coding section names at call sites.
- **Connection-string selection is environment-gated**: `Development` uses `ConnectionStrings:DefaultConnection` (LocalDB), any other environment uses `ConnectionStrings:ProductionConnection` (Azure SQL). See the `#region Database Context` block in `DependentServiceCollection.cs`.
- In non-Development environments, startup **throws** if `Authentications_FacebookSignIn_facebookappid`/`facebookappsecret` env vars are missing — these come from environment variables / Azure App Configuration, not `appsettings.json`.
- Logging uses **NLog** (config in `src/Web/nlog.config`, wired via `builder.Host.UseNLog()`) plus Azure App Services file + blob loggers. The NLog `logDir` variable points at `C:\Logs\` by default.

## Data model

- `FortuneDbContext : IdentityDbContext<IdentityUser>` (note: base Identity type is `IdentityUser`, but `Data.Entity.ApplicationUser` also exists and is used in custom handlers — keep this distinction in mind when touching Identity-related code).
- Application tables are placed in the **`fort` schema** via `entity.ToTable("Name", "fort")` in `OnModelCreating`; ASP.NET Identity tables stay in the default schema.
- DbSets: `Categories`, `Comments`, `Posts`, `PostCategories`, `UserPosts`, `Suggestions`, `UserDetails`.

## Authorization

Custom policies (names in `Core.Constants.ResourcePolicy`, role/claim values in `Core.Constants.ResourceAction`):

- `IsTobiKareem` — requires `Role == "Fortune_Admin"`.
- `HasWriteAccess` / `HasEditAccess` — require `CanWritePost` / `CanEditPost` role claims.
- `HasFullCreateAccess` — uses `AllowedFullAccessRequirement` + `FullAccessHandler` (singleton).
- `OwnerCanEdit` — **resource-based**: uses `IsPostOwnerRequirement` + `IsPostOwnerRequirementHandler` (scoped) which checks `Post.CreatedBy == currentUserId`. When authorizing via this policy, pass the `Post` as the resource to `IAuthorizationService.AuthorizeAsync`.

## Repository / service conventions

- Generic repository interfaces live in `Shared.Interfaces.Repository`: `IBaseStore<T>` (Add/Update/GetAll + cache hints), `IDataStore<T>` (adds int-id CRUD + `GetByUserId`), `IStringIdStore<T>` (string-id variant used for Identity users).
- `IBaseStore<T>.AddEntity` / `UpdateEntity` take optional `CacheEntry` + `hasCache` parameters — repositories consult `ICacheService` (`MemoryCache` wrapper) keyed by the `Core.Constants.CacheEntry` enum rather than raw strings.
- Service lifetimes used in `ConfigureCustomServices`: business services are `Scoped`, repositories are mostly `Transient`, `CacheService`/`EmailSender` follow the same scoping — match existing patterns when adding a new registration.

## Deployment topology (Azure)

Hosted in the **`FortuneWeb`** resource group (subscription `FortuneWeb`, `5a44eaa5-…`). Verified layout:

- **App Service `tobikareem`** + plan `ASP-FortuneWeb-b9db` — **centralus**. Serves custom domain `www.tobikareem.com` (bound TLS cert in the same RG).
- **Azure SQL server `fortuneweb`** — **westus3**. Databases: `FortuneDb` (the app DB referenced by `ConnectionStrings:ProductionConnection`), `SlimWebDB` (appears unused — candidate for cleanup), and `master`.
- **Storage `tobikareemlogs`** (NLog blob sink) and **App Insights `tobikareem`** — centralus.
- **Region split:** app + storage + insights live in **centralus** while SQL lives in **westus3**, so app↔DB traffic is cross-region (~10–20 ms). Not a bug, but factor it in before adding chatty DB access. Note: an App Service's region is fixed at creation and can't be moved in place — consolidating means recreating the app (manual; Resource Mover doesn't support App Service) or relocating the SQL DB (Resource Mover *does* support Azure SQL).

## Gotchas

- The solution currently has **hard-coded Facebook/Twitter/Spotify client secrets inline** in `DependentServiceCollection.cs` alongside the config-driven path. Treat this as a known smell; prefer fixing to read from `IOptions<T>` / env vars rather than propagating more inline secrets.
- **`ConfigureCustomServices` calls `services.AddAuthorization(...)` twice** (`DependentServiceCollection.cs:82` and `:143`) and registers the **`IsTobiKareem` policy in both**. Policy names are dictionary keys, so the **second registration wins** — the effective policy is the claim-based `RequireClaim(ClaimTypes.Role, ResourceAction.FortuneAdmin)` (`= "Fortune_Admin"`). The first block's `RequireRole("FortuneAdmin")` is **dead code**, and its literal role string `"FortuneAdmin"` doesn't even match the real value `"Fortune_Admin"`. When changing this policy, edit the second block (`:143-170`) and consider deleting the first — don't "fix" line 84 expecting it to take effect.
- `src/Web/appsettings.json` also contains committed secrets (SendGrid key, Google service-account private key, OAuth client secrets). Do not add new secrets there — use User Secrets in dev and Azure App Configuration / env vars elsewhere.
- `Data/` at the repo root (CSV files) is a **table-by-table export of the production dataset** (real user PII, ASP.NET Identity password hashes, OAuth tokens) — not the `src/Data` project and **not** synthetic seed data. It is **gitignored** (`/Data/`); never commit it. Load it into local LocalDB with the DataSeeder tool (see Common commands).
- **EF migrations are bound to `FortuneDbContext` via `[DbContext(typeof(FortuneDbContext))]`** on each migration. Calling `Database.Migrate()` on a *subclass* of `FortuneDbContext` silently discovers **zero** migrations and creates an empty database (only `__EFMigrationsHistory`) — symptom: `Invalid object name 'AspNetUsers'` on first query. Run schema/migrate operations on a real `FortuneDbContext` instance (see `src/Tools/DataSeeder/Seeder.cs`, which uses `FortuneDbContext` for drop+migrate and a thin subclass only for explicit-key inserts).
- **The model has drifted from the 2022 migration snapshot** (net9 upgrade), so programmatic `Database.Migrate()` throws EF 9's `PendingModelChangesWarning` (promoted to an error). For tooling that just needs the existing migrations applied, suppress it via `optionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning))`. If you intend to evolve the schema for real, add a fresh migration instead of suppressing.
- `.editorconfig` suppresses `CS8618` (non-nullable field must be initialized) globally — don't assume nullability warnings are enforced.
