using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Core.Models;

namespace Web.Pages
{
    public class AboutModel : PageModel
    {

        [BindProperty] public UserForm Input { get; set; }

        public AboutModel()
        {
            Input = new UserForm();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            return RedirectToPage("/Home");
        }
    }
}
