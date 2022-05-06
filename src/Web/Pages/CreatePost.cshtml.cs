using System.Security.Claims;
using Core.Constants;
using Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Interfaces.Services;

namespace Web.Pages
{
    [Authorize]
    public class CreatePostModel : PageModel
    {
        [BindProperty] public Post UserPost { get; set; }
        private readonly IPostService _postService;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public CreatePostModel(IPostService postService, UserManager<ApplicationUser> userManager)
        {
            _postService = postService;
            _userManager = userManager;

            UserPost = new Post { IsPublished = true, Category = new Category()};
        }


        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            UserPost.UserId = user.Id;
            UserPost.CreatedBy = User.FindFirstValue(ClaimTypes.GivenName) ?? User.FindFirstValue("FirstName");
            UserPost.Enabled = true;
            
            _postService.CreateNewPost(UserPost, CacheEntry.Posts, true);
            return RedirectToPage("./Writer");

        }

    }
}
