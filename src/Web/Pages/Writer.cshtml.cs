using Shared.Interfaces.Repository;
using Data.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class WriterModel : PageModel
    {
        private readonly IDataStore<Post> blogPostRepo;
        public List<Post> BlogPosts { get; set; }

        public WriterModel(IDataStore<Post> blogPostRepo)
        {
            this.blogPostRepo = blogPostRepo;
            BlogPosts = new List<Post>();
        }

        public void OnGet()
        {
            var blog = blogPostRepo.GetAll();

            // BlogPosts = blog.Where(x => x.Category.Category1.ToLower() != "mindfeed").ToList();
        }

    }
}
