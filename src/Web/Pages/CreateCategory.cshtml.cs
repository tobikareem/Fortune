#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Constants;
using Data.Entity;
using Shared.Interfaces.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Shared.Interfaces.Services;

namespace Web.Pages
{
    [Authorize(ResourcePolicy.IsTobiKareem)]
    public class CreateCategoryModel : PageModel
    {
        private readonly IDataStore<Category> _category;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICacheService _cacheService;

        public CreateCategoryModel(IDataStore<Category> context, UserManager<ApplicationUser> userManager, ICacheService cacheService)
        {
            _category = context;
            _userManager = userManager;
            _cacheService = cacheService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            Category.CreatedBy = user.Id;
            Category.CreatedOn = DateTime.UtcNow;
            Category.Enabled = true;

            var allCategories =  _cacheService.GetOrCreate(CacheEntry.GetAllCategories, _category.GetAll, 120);

            if (allCategories.Any(x => x.Category1 == Category.Category1))
            {
                return Page();
            }
            
            _category.AddEntity(Category);
            _cacheService.Remove(CacheEntry.GetAllCategories);
            
            return RedirectToPage("./Index");

        }
    }
}
