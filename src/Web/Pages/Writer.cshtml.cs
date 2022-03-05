using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Interfaces.Repository;
using Core.Models;

namespace Web.Pages
{
    public class WriterModel : PageModel
    {

        private readonly IBlogPostService blogPostService;

        public List<BlogPost> BlogPosts { get; set; }

        public WriterModel(IBlogPostService blogPostService)
        {
            this.blogPostService = blogPostService;
        }
        public void OnGet()
        {
            BlogPosts = blogPostService.GetAllBlogPosts().ToList();
        }


    }
}
