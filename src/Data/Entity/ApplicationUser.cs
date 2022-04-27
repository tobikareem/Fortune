
using Microsoft.AspNetCore.Identity;
namespace Data.Entity
{
    public sealed class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {
            Posts = new HashSet<Post>();
            UserPosts = new HashSet<UserPost>();
        }

        public ICollection<Post> Posts { get; set; }
        public ICollection<UserPost> UserPosts { get; set; }
        public ICollection<UserDetail> UserDetails { get; set; }
    }
}
