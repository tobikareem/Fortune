using System.Security.Claims;
using Core.Constants;
using Shared.Interfaces.Repository;
using Data.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class WriterModel : PageModel
    {
        private readonly IDataStore<Post> _blogPostRepo;
        public bool IsTobiKareem { get; set; }
        public List<Post> BlogPosts { get; set; }

        public WriterModel(IDataStore<Post> blogPostRepo)
        {
            this._blogPostRepo = blogPostRepo;
            BlogPosts = new List<Post>();
        }

        public void OnGet()
        {
            IsTobiKareem = User.HasClaim(ClaimTypes.Role, ResourceAction.FortuneAdmin);
            
            var blog = _blogPostRepo.GetAll();

            BlogPosts = blog.Where(x => x.Category.Category1.ToLower() != "mindfeed").ToList();
        }

    }
}
