namespace Data.Entity
{
    public partial class Category : Core.Models.Category
    {
        public Category()
        {
            PostCategories = new HashSet<PostCategory>();
            Posts = new HashSet<Post>();
        }
        public virtual ICollection<PostCategory> PostCategories { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
