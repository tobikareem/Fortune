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
