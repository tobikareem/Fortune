using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty] public UserForm Input { get; set; }

        public ContactModel()
        {
            Input = new UserForm();
        }

        public void OnGet()
        {
        }
    }
}
