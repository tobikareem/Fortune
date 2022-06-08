#nullable disable
using Core.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Entity;
using Microsoft.AspNetCore.Identity;
using Shared.Interfaces.Repository;
using Shared.Interfaces.Services;

namespace Web.Pages
{
    public class EditPostModel : PageModel
    {
        private readonly IPostService _postService;
        private readonly IDataStore<Post> _postRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public EditPostModel(IPostService postService, UserManager<ApplicationUser> userManager, IDataStore<Post> postRepository)
        {
            _postService = postService;
            _userManager = userManager;
            _postRepository = postRepository;
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
                var existingPost = _postRepository.GetById(Post.Id);
                
                existingPost.Content = Post.Content;
                existingPost.Description = Post.Description;
                existingPost.Title = Post.Title;
                existingPost.ModifiedOn = DateTime.UtcNow;
                existingPost.ModifiedBy = user;
                existingPost.CategoryId = Post.CategoryId;

                _postService.UpdatePost(existingPost, CacheEntry.Posts, true);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(Post.Id))
                {
                    return NotFound();
                }
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
