#nullable disable
using Core.Constants;
using Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Shared.Interfaces.Repository;
using Shared.Interfaces.Services;

namespace Web.Pages
{
    [Authorize(ResourcePolicy.HasFullCreateAccess)]
    public class DashboardModel : PageModel
    {

        private readonly IDataStore<Post> _postDataStore;
        private readonly IUserService _userService;
        public DashboardModel(IDataStore<Post> postDataStore, IUserService userService)
        {
            _postDataStore = postDataStore;
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            var userId = _userService.GetCurrentUserId(User);
            var posts = _postDataStore.GetByUserId(userId).ToList();

            if (posts.Any())
            {
                return Page();
            }
            
            return RedirectToPage("/Account/Manage/Index", new { area = "Identity" });
        }

    }
}
