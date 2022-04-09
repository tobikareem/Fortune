using System;
using System.Collections.Generic;

namespace Data.Entity
{
    public partial class Post : Core.Models.Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            PostCategories = new HashSet<PostCategory>();
            UserPosts = new HashSet<UserPost>();
        }
        public virtual Category Category { get; set; }
        public virtual ApplicationUser? User { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PostCategory> PostCategories { get; set; }
        public virtual ICollection<UserPost> UserPosts { get; set; }
    }
}
