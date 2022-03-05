namespace Core.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CategoryEnum Category { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public string Date { get; set; }
        public string Tags { get; set; }

    }
}
