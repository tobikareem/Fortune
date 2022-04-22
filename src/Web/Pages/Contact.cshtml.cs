using Core.Configuration;
using Core.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Interfaces.Services;
using Microsoft.Extensions.Options;


namespace Web.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty] public UserForm Input { get; set; }

        private readonly IEmailSender _mailSender;
        private readonly EmailProp _emailProp;


        public ContactModel(IEmailSender message, IOptions<EmailProp> appSetting)
        {
            _mailSender = message;
            _emailProp = appSetting.Value;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            return RedirectToPage();
        }
    }
}
