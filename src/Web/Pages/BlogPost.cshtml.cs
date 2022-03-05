using Core.Interfaces.Repository;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Web.Pages
{
    public class BlogPostModel : PageModel
    {

        private readonly IBlogPostService blogPostService;

        public BlogPost BlogPost { get; set; }

        public BlogPostModel(IBlogPostService blogPostService)
        {
            this.blogPostService = blogPostService;

            BlogPost = new BlogPost();
        }

        public IActionResult OnGet(int id)
        {
            var blog = blogPostService.GetAllBlogPosts().FirstOrDefault(b => b.Id == id);

            if(blog == null)
            {
                throw new Exception("Invalid Status Page");
            }

            BlogPost = blog;

            return Page();
        }
    }
}
