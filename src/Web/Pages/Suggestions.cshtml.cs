#nullable disable
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Data.Entity;
using Shared.Interfaces.Repository;
using System.Security.Claims;

namespace Web.Pages
{
    public class SuggestionsModel : PageModel
    {
        private readonly IBaseStore<Suggestions> _context;
        [BindProperty] public Suggestion Suggest { get; set; }
        public List<Suggestions> SuggestionsList { get; set; }
        
        public SuggestionsModel(IBaseStore<Suggestions> context)
        {
            _context = context;
            Suggest = new Suggestion();
            
            SuggestionsList = _context.GetAll().OrderByDescending(x => x.CreatedOn).ToList();
        }

        public IActionResult OnGet()
        {
            // Check if the user is logged in
            if (User.Identity is not { IsAuthenticated: true })
            {
                return Page();
            }

            Suggest.CreatedBy = User.FindFirst(ClaimTypes.GivenName)?.Value;
            return Page();
        }


        // To protect from over posting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            // if the suggestion.has expired is true, then Suggestions.ExpiredDate is required and must be in the future
            if (Suggest.HasExpiryTime)
            {
                if (Suggest.ExpireBy <= DateTime.Now)
                {
                    ModelState.AddModelError(nameof(Suggest.ExpireBy), "Expired By must be in the future");
                    return Page();
                }
            }

            var suggestion = new Suggestions
            {
                Enabled = true,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = Suggest.CreatedBy,
                HasExpiryTime = Suggest.HasExpiryTime,
                ExpireBy = Suggest.ExpireBy,
                Title = Suggest.Title,
                Content = Suggest.Content
            };

            _context.AddEntity(suggestion);
            return RedirectToPage("./Home");
        }


        public class Suggestion
        {
            [Required(ErrorMessage = "Full Name is Required"), Display(Name = "FullName")]
            public string CreatedBy { get; set; }
            
            [Required, Display(Name = "Suggestion")]
            public string Content { get; set; }

            [Display(Name = "Expire By")]
            public DateTime ExpireBy { get; set; }
            
            [Required]
            public string Title { get; set; }

            [Display(Name = "Has Time Limit")]
            public bool HasExpiryTime { get; set; }
        }

    }
}
