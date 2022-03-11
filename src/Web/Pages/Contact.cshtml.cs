using Core.Configuration;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Interfaces.Services;
using Microsoft.Extensions.Options;


namespace Web.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty] public UserForm Input { get; set; }

        private readonly IMailMessage mailMessage;

        private readonly EmailProp appSetting;
        private readonly ConnectionStrings connString;


        public ContactModel(IMailMessage message, IOptions<EmailProp> conAppsetting, IOptions<ConnectionStrings> conString)
        {
            Input = new UserForm();

            mailMessage = message;
            appSetting = conAppsetting.Value;
            connString = conString.Value;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            mailMessage.SendMessage(Input.Email, appSetting.MyEmail, appSetting.Subject, Input.Message);

            return RedirectToPage();
        }
    }
}
