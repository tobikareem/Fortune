
using Microsoft.AspNetCore.Identity;
namespace Data.Entity
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {
            Posts = new HashSet<Post>();
            UserPosts = new HashSet<UserPost>();
        }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<UserPost> UserPosts { get; set; }
    }
}
