using Data.Context;
using Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DataSeeder;

public sealed class Seeder
{
    private readonly SeederDbContext _ctx;
    private readonly string _connectionString;
    private readonly string _dataPath;

    public Seeder(SeederDbContext ctx, string connectionString, string dataPath)
    {
        _ctx = ctx;
        _connectionString = connectionString;
        _dataPath = dataPath;
    }

    public void Run()
    {
        // Schema (drop + migrate) must run on the real FortuneDbContext: EF Core
        // discovers migrations by their [DbContext(typeof(FortuneDbContext))]
        // attribute, so Migrate() on the SeederDbContext subclass finds none.
        var schemaOptions = new DbContextOptionsBuilder<FortuneDbContext>()
            .UseSqlServer(_connectionString, sql => sql.MigrationsAssembly("Data"))
            // The model has drifted from the 2022 migration snapshot (net9 upgrade);
            // we only need the existing migrations to build a schema for the seed.
            .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning))
            .Options;

        using (var schemaCtx = new FortuneDbContext(schemaOptions))
        {
            Console.WriteLine("Dropping local database...");
            schemaCtx.Database.EnsureDeleted();

            Console.WriteLine("Applying migrations...");
            schemaCtx.Database.Migrate();
        }

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
