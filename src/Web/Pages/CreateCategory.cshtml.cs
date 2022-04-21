#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Constants;
using Data.Entity;
using Shared.Interfaces.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Web.Pages
{
    [Authorize(ResourcePolicy.HasWriteAccess)]
    public class CreateCategoryModel : PageModel
    {
        private readonly IDataStore<Category> _category;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateCategoryModel(IDataStore<Category> context, UserManager<ApplicationUser> userManager)
        {
            _category = context;
            _userManager = userManager;
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

            if (_category.GetAll().Any(x => x.Category1 == Category.Category1))
            {
                return Page();
            }
            
            _category.AddEntity(Category);
            return RedirectToPage("./Index");

        }
    }
}
