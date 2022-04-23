using Core.Configuration;
using Google.Analytics.Data.V1Beta;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using Shared.Interfaces.Services;

namespace Shared.Services
{
    public class CallsService : IServiceCalls
    {
        private readonly GoggleAnalytics _googleAnalytics;
        private readonly EmailProp _emailProp;
        public CallsService(IOptions<EmailProp> emailOptions, IOptions<GoggleAnalytics> config)
        {
            _googleAnalytics = config.Value;
            _emailProp = emailOptions.Value;
        }


        public async Task<Response> SendGridEmail(string toEmail, string subject, string plainTextContent, string recipientName = "", string htmlContent = "")
        {
            var apiKey = _emailProp.SendGridApiKey;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(_emailProp.FromEmail, _emailProp.MyEmailName);
            var to = new EmailAddress(toEmail, recipientName);

            // const string htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            //  msg.SetClickTracking(false, false);

            var response = await client.SendEmailAsync(msg);

            return response;

        }
        
        public async Task GetGoggleAnalytics()
        {
            var propertyId = _googleAnalytics.ProjectId;

            // Using a default constructor instructs the client to use the credentials
            // specified in GOOGLE_APPLICATION_CREDENTIALS environment variable.
            var client = await BetaAnalyticsDataClient.CreateAsync();

            // Initialize request argument(s)
            var request = new RunReportRequest
            {
                Property = "properties/" + propertyId,
                Dimensions = { new Dimension { Name="city" }, },
                Metrics = { new Metric { Name="activeUsers" }, },
                DateRanges = { new DateRange { StartDate="2020-03-31", EndDate="today" }, },
            };

            // Make the request
            var response = await client.RunReportAsync(request);

            Console.WriteLine("Report result:");
            foreach (var row in response.Rows)
            {
                Console.WriteLine("{0}, {1}", row.DimensionValues[0].Value, row.MetricValues[0].Value);
            }
        }
    }
}
