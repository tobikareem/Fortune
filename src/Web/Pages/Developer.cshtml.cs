using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class DeveloperModel : PageModel
    {

        [BindProperty] public UserForm Input { get; set; }

        public DeveloperModel()
        {
            Input = new UserForm();
        }

        public void OnGet()
        {
        }
    }
}
