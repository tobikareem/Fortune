#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Entity;
using Microsoft.AspNetCore.Identity;
using Shared.Interfaces.Services;

namespace Web.Pages
{
    public class EditPostModel : PageModel
    {
        private readonly IPostService _postService;
        private readonly UserManager<ApplicationUser> _userManager;

        public EditPostModel(IPostService postService, UserManager<ApplicationUser> userManager)
        {
            _postService = postService;
            _userManager = userManager;
        }

        [BindProperty]
        public Post Post { get; set; }

        public IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = _postService.GetPostById(id.GetValueOrDefault());

            if (Post == null)
            {
                return NotFound();
            }
            return Page();
        }
        
        public  IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            

            try
            {
                var user = _userManager.GetUserId(User);
                var existingPost = _postService.GetPostById(Post.Id);
                
                existingPost.Content = Post.Content;
                existingPost.Description = Post.Description;
                existingPost.Title = Post.Title;
                existingPost.ModifiedOn = DateTime.UtcNow;
                existingPost.ModifiedBy = user;

                _postService.UpdatePost(existingPost);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(Post.Id))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("./Writer");
        }

        private bool PostExists(int id)
        {
            var post = _postService.GetPostById(id);
            return post.Id != default;
        }
    }
}
