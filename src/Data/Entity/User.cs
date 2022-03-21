using System;
using System.Collections.Generic;

namespace Data.Entity
{
    public partial class User : Core.Models.User
    {
        public User()
        {
            Posts = new HashSet<Post>();
            UserPosts = new HashSet<UserPost>();
            Identifier = Guid.NewGuid().ToString();
        }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<UserPost> UserPosts { get; set; }
    }
}
