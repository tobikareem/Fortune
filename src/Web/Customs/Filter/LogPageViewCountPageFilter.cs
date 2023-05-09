using Core.Constants;
using Data.Entity;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Timers;
using Tweetinvi.Core.Extensions;
using Timer = System.Timers.Timer;

namespace Web.Customs.Filter
{
    public class LogPageViewCountPageFilter : IPageFilter
    {
        private readonly ILogger<LogPageViewCountPageFilter> _logger;

        private Dictionary<string, LogPageViewCount> _logPageViewDictionary;

        private static Timer _timer;
        public LogPageViewCountPageFilter(ILogger<LogPageViewCountPageFilter> logger)
        {
            _logger = logger;

            _logPageViewDictionary = new Dictionary<string, LogPageViewCount>();

            SetTimer();
        }
        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            var path = context.ActionDescriptor.RouteValues["page"] ?? "unknown";

            if (string.Compare(path, "/blogPost", StringComparison.OrdinalIgnoreCase) != 0)
            {
                return;
            }

            path = context.HttpContext.Request.Path.HasValue ? context.HttpContext.Request.Path.Value : "";

            _logPageViewDictionary.TryGetValue(path, out var pageView);

            pageView ??= new LogPageViewCount();

            pageView.Count++;
            pageView.EndPoint = path;
            pageView.CreatedAt = DateTime.UtcNow;

            var user = context.HttpContext.User;
            if (user.Identity is { IsAuthenticated: true })
            {
                pageView.UserName = user.FindFirst("FirstName")?.Value;
            }


            _logPageViewDictionary.AddOrUpdate(path, pageView);
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.

            var seconds = TimeSpan.FromMinutes(2).TotalSeconds;

            _timer = new Timer(60000);
            // Hook up the Elapsed event for the timer. 
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            // save to database

            foreach (var logPageViewCount in _logPageViewDictionary)
            {
                LogPageViewCount logPage;
                var path = logPageViewCount.Key;
                _logPageViewDictionary.TryGetValue(path, out logPage);
                _logger.LogInformation(PageLogEventId.PageViewCount, "Path - {path}, User - {user}, Count - {count}, SignalTime {signal}", path, logPage.UserName, logPage.Count, e.SignalTime);
            }

            // refresh the dictionary
            // _logPageViewDictionary.Clear();
        }
    }
}
