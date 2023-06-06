using Core.Constants;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Shared.Interfaces.Services;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Shared.Services
{
    public class EmailSender: IEmailSender
    {
        private readonly ILogger<EmailSender> _logger;
        private readonly IExternalApiCalls _serviceCalls;

        public EmailSender(ILogger<EmailSender> logger, IExternalApiCalls serviceCalls)
        {
            _logger = logger;
            _serviceCalls = serviceCalls;
        }
        
        public async Task SendEmailAsync(string toEmail, string subject, string htmlMessage)
        {
            _logger.Log(LogLevel.Information, PageLogEventId.EmailMessageInformation, $"Sending email to {toEmail}", subject);
            
            var response =  await _serviceCalls.SendGridEmail(toEmail, subject, string.Empty, htmlContent:htmlMessage);

            if (response.IsSuccessStatusCode)
            {
                _logger.Log(LogLevel.Information, PageLogEventId.EmailMessageInformation, $"Email sent to {toEmail}", subject);
            }
            else
            {
                _logger.Log(LogLevel.Error, PageLogEventId.EmailMessageInformation, $"Email failed to send to {toEmail}", subject, response.Body);
            }
        }

    }
}
