using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Post: GeneralEntity
    {
        public string Title { get; set; } 
        public string Description { get; set; }

        public string Content { get; set; }
        public string UserId { get; set; }
        public int? CategoryId { get; set; }
        public bool IsPublished { get; set; }

        public bool IsReviewPost { get; set; }

        public virtual Category Category { get; set; }
    }
}
