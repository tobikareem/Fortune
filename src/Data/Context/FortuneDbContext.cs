using Core.Configuration;
using Data.Entity;
using System.Linq;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Data.Context
{
    public partial class FortuneDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly ConnectionStrings connStrings;
        public FortuneDbContext(IOptions<ConnectionStrings>options)
        {
            connStrings = options.Value;
        }

        public FortuneDbContext(DbContextOptions<FortuneDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostCategory> PostCategories { get; set; }
        // public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserPost> UserPosts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connStrings.DefaultConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category", "fort");

                entity.HasIndex(e => e.Category1, "idx_nc_category");

                entity.Property(e => e.Category1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Category");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ModifiedOn);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Enabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(55)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment", "fort");

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ModifiedOn);

                entity.Property(e => e.Enabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommentPost");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post", "fort");

                entity.HasIndex(e => e.Title, "idx_nc_post_title");

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ModifiedOn);

                entity.Property(e => e.IsPublished);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Enabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Post_Category_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_User_Id");
            });

            modelBuilder.Entity<PostCategory>(entity =>
            {
                entity.ToTable("PostCategory", "fort");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PostCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostCategory_Category");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostCategories)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostCategory_Post");
            });

            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.ToTable("User", "fort");

            //    entity.HasIndex(e => e.DisplayName, "idx_nc_displayname");

            //    entity.Property(e => e.CreatedBy)
            //        .HasMaxLength(55)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getutcdate())");

            //    entity.Property(e => e.ModifiedOn);

            //    entity.Property(e => e.DisplayName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Email)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Enabled)
            //        .IsRequired()
            //        .HasDefaultValueSql("((1))");

            //    entity.Property(e => e.FirstName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Identifier)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LastName)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ModifiedBy)
            //        .HasMaxLength(55)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Phone).HasMaxLength(50);
            //});

            modelBuilder.Entity<UserPost>(entity =>
            {
                entity.ToTable("UserPost", "fort");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.UserPosts)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPost_Post");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPosts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPost_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
