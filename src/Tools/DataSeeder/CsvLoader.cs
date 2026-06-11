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

    // Counts logical data records (RFC-4180 aware) — quoted fields containing
    // newlines, e.g. Post.Content HTML, count as one record, not many lines.
    public static int CountRecords(string path)
    {
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, BuildConfig());
        csv.Read();
        csv.ReadHeader();
        var count = 0;
        while (csv.Read())
            count++;
        return count;
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
