using Shared.Interfaces.Repository;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class BlogPostModel : PageModel
    {

        private readonly IDataStore<Data.Entity.Post> blogPostRepo;

        [BindProperty] public Comment CommentUser { get; set; }

        public Post BlogPost { get; set; }

        public BlogPostModel(IDataStore<Data.Entity.Post> blogPostRepo)
        {
            this.blogPostRepo = blogPostRepo;

            CommentUser = new Comment();
            BlogPost = new Post();
        }

        public IActionResult OnGet(int id)
        {
            var blog = blogPostRepo.GetById(id);

            if(blog == null)
            {
                throw new Exception("Invalid Status Page");
            }

            BlogPost = blog;

            return Page();
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
