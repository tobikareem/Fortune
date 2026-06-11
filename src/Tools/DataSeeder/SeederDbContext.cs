using Data.Context;
using Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

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
            optionsBuilder
                .UseSqlServer(_connectionString, sql => sql.MigrationsAssembly("Data"))
                .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
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
