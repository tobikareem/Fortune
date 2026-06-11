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
            // This context is used only for data inserts; schema drop/migrate
            // runs on a real FortuneDbContext in Seeder.cs (migrations are bound
            // to that type, and the PendingModelChangesWarning suppression lives there).
            optionsBuilder.UseSqlServer(_connectionString);
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
