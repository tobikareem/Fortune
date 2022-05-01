using Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Category = Data.Entity.Category;
using Comment = Data.Entity.Comment;
using Post = Data.Entity.Post;
using PostCategory = Data.Entity.PostCategory;
using UserPost = Data.Entity.UserPost;

namespace Data.Context
{
    public partial class FortuneDbContext : IdentityDbContext<IdentityUser>
    {
        //private readonly ConnectionStrings connStrings;
        public FortuneDbContext()
        {
        }

        public FortuneDbContext(DbContextOptions<FortuneDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostCategory> PostCategories { get; set; }
        public virtual DbSet<UserPost> UserPosts { get; set; }
        public virtual DbSet<Suggestions> Suggestions { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               // optionsBuilder.UseSqlServer();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.ToTable("UserDetails", "fort");

                entity.Property(e => e.Id).HasColumnName("Id").IsRequired();

                entity.Property(e => e.UserId).HasColumnName("UserId").IsRequired();

                entity.Property(e => e.Title).HasColumnName("Title").HasMaxLength(55);

                entity.Property(e => e.Company).HasMaxLength(55);

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.WebsiteUrl);

                entity.Property(e => e.FacebookLink).HasMaxLength(155);

                entity.Property(e => e.TwitterLink).HasMaxLength(155);

                entity.Property(e => e.LinkedInLink).HasMaxLength(155);

                entity.Property(e => e.InstagramLink).HasMaxLength(155);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy);

                entity.Property(e => e.ModifiedBy);

                entity.Property(e => e.DriveFileId);

                entity.Property(e => e.Enabled);
                entity.Property(e => e.Location);
                entity.Property(e => e.IsSubscribed);

                // create a foreign key to aspnetusers
                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UserDetails_AspNetUsers");



            });

            modelBuilder.Entity<Suggestions>(entity =>
            {
                entity.ToTable("Suggestions", "fort");

                entity.Property(e => e.Id).HasColumnName("Id").IsRequired();

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.HasExpiryTime);

                entity.Property(e => e.Title);

                entity.Property(e => e.ExpireBy);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn);

                entity.Property(e => e.ModifiedOn);

                entity.Property(e => e.Enabled)
                    .IsRequired();

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(55)
                    .IsUnicode(false);
            });
            
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

                entity.Property(e => e.CreatedOn);

                entity.Property(e => e.ModifiedOn);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Enabled)
                    .IsRequired();

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

                entity.Property(e => e.CreatedOn);

                entity.Property(e => e.ModifiedOn);

                entity.Property(e => e.Enabled)
                    .IsRequired();

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.Cascade)
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

                entity.Property(e => e.CreatedOn);

                entity.Property(e => e.ModifiedOn);

                entity.Property(e => e.IsPublished);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Enabled)
                    .IsRequired();

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
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Post_User_Id");
            });

            modelBuilder.Entity<PostCategory>(entity =>
            {
                entity.ToTable("PostCategory", "fort");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PostCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PostCategory_Category");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostCategories)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PostCategory_Post");


            });

            modelBuilder.Entity<UserPost>(entity =>
            {
                entity.ToTable("UserPost", "fort");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.UserPosts)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UserPost_Post");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPosts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UserPost_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
