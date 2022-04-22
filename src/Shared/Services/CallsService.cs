using Core.Configuration;
using Google.Analytics.Data.V1Beta;
using Microsoft.Extensions.Options;
using Shared.Interfaces.Services;

namespace Shared.Services
{
    public class CallsService : IServiceCalls
    {
        private readonly GoggleAnalytics _googleAnalytics;
        public CallsService(IOptions<GoggleAnalytics> config)
        {
            _googleAnalytics = config.Value;
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
