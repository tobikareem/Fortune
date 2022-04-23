
using SendGrid;
namespace Shared.Interfaces.Services
{
    public interface IServiceCalls
    {
        Task<Response> SendGridEmail(string toEmail, string subject, string plainTextContent, string recipientName = "",
            string htmlContent = "");
        Task GetGoggleAnalytics();
    }
}
