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
