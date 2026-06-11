using DataSeeder;
using Microsoft.EntityFrameworkCore;
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
