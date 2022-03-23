using Core.Configuration;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Interfaces.Services;
using Microsoft.Extensions.Options;


namespace Web.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty] public UserForm Input { get; set; }

        private readonly IMailMessage mailMessage;

        private readonly EmailProp appSetting;


        public ContactModel(IMailMessage message, IOptions<EmailProp> conAppsetting)
        {
            Input = new UserForm();

            mailMessage = message;
            appSetting = conAppsetting.Value;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            mailMessage.SendMessage(Input.Email, appSetting.MyEmail, appSetting.Subject, Input.Message);

            return RedirectToPage();
        }
    }
}
