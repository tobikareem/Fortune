using Core.Configuration;
using Core.Constants;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Interfaces.Services;
using Microsoft.Extensions.Options;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;


namespace Web.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty] public UserForm Input { get; set; }
        
        private readonly EmailProp _emailProp;
        private readonly IExternalApiCalls _serviceCalls;
        private readonly ILogger<ContactModel> _logger;


        public ContactModel(IOptions<EmailProp> appSetting, IExternalApiCalls serviceCalls, ILogger<ContactModel> logger)
        {
            _emailProp = appSetting.Value;
            _serviceCalls = serviceCalls;
            _logger = logger;
        }
        public async Task<IActionResult> OnGet()
        {
            // await _serviceCalls.GetGoogleAnalyticsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var msg = Input.Message + " Email: " + Input.Email + " Name: " + Input.FirstName + Input.LastName;
            
            var response = await _serviceCalls.SendGridEmail(_emailProp.FromEmail, EmailText.ContactMeSubject, msg, Input.FirstName + " " + Input.LastName, string.Empty);

            if (response.IsSuccessStatusCode)
            {
                _logger.Log(LogLevel.Information, PageLogEventId.EmailMessageInformation, "Email sent successfully");
            }
            else
            {
                _logger.Log(LogLevel.Error, PageLogEventId.EmailMessageInformation, "Email could not be sent successfully", response.Body);
            }

            return RedirectToPage("/ContactConfirmation");
        }
    }
}
