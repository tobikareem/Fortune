using System.Diagnostics;
using System.Net;
using System.Timers;
using Core.Constants;
using Core.Models;
using Data.Entity;
using Newtonsoft.Json;
using Tweetinvi.Core.Extensions;
using Timer = System.Timers.Timer;

namespace Web.Extensions
{

    /// <summary>
    /// Custom Middleware for global error handling
    /// Maps all the exception to an appropriate HTTP Status code
    /// </summary>
    public class CustomErrorLogMiddleware
    {
        #region Field Declaration
        /// status code 400
        private static readonly List<Type> BadRequestTypes = new()
        {
            typeof(ArgumentException),
            typeof(ArgumentNullException),
            typeof(ArgumentOutOfRangeException)
        };

        // status code 401
        private static readonly List<Type> BadAuthTypes = new()
        {
            typeof(UnauthorizedAccessException),
            typeof(FieldAccessException)
        };

        // status code 403
        private static readonly List<Type> BadOperationTypes = new()
        {
            typeof(InvalidCastException),
            typeof(InvalidOperationException),
            typeof(InvalidProgramException),
            typeof(NotImplementedException),
            typeof(MissingMethodException),
        };

        // status code 404
        private static readonly List<Type> BadNoResourceTypes = new()
        {
            typeof(MissingFieldException),
            typeof(MissingMemberException),
            typeof(KeyNotFoundException),
        };

        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<CustomErrorLogMiddleware> _logger;
        #endregion

        private readonly Dictionary<string, LogPageViewCount> _logPageViewDictionary;
        private static Timer _timer;
        public CustomErrorLogMiddleware(RequestDelegate next, ILogger<CustomErrorLogMiddleware> logger)
        {
            _requestDelegate = next;
            _logger = logger;
            _logPageViewDictionary = new Dictionary<string, LogPageViewCount>();

            SetTimer();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var timer = Stopwatch.StartNew();
            var data = GetData(context);

            try
            {
                await _requestDelegate(context);

                LogBlogPostPath(context);
            }
            catch (Exception e)
            {
                data.Error = e.Message;

                LogException(context, e, data);

                data.Duration = timer.Elapsed.TotalSeconds;
                _logger.Log(LogLevel.Error, PageLogEventId.CustomErrorLogMiddleWare, data.Message);
            }

            //data.Duration = data.Duration == 0 ?  timer.Elapsed.TotalSeconds : data.Duration;
            
            //_logger.Log(LogLevel.Information, PageLogEventId.CustomErrorLogMiddleWare, data.Message);
        }

        private void LogBlogPostPath(HttpContext context)
        {
            var path = context.Request.RouteValues.TryGetValue("page", out var pathValue) ? pathValue?.ToString() : "unknown";

            if (string.Compare(path, "/blogPost", StringComparison.OrdinalIgnoreCase) != 0)
            {
                return;
            }

            path = context.Request.Path.HasValue ? context.Request.Path.Value : "";            
            _logPageViewDictionary.TryGetValue(path, out var pageView);

            pageView ??= new LogPageViewCount();

            pageView.Count++;
            pageView.EndPoint = path;
            pageView.CreatedAt = DateTime.UtcNow;

            var user = context.User;
            if (user.Identity is { IsAuthenticated: true })
            {
                pageView.UserName = user.FindFirst("FirstName")?.Value;
            }


            _logPageViewDictionary.AddOrUpdate(path, pageView);
        }

        private static void LogException(HttpContext context, Exception exception, PageTracking data)
        {
            var code = HttpStatusCode.InternalServerError;

            if (BadAuthTypes.Contains(exception.GetType()))
            {
                code = HttpStatusCode.Unauthorized;
            }

            else if (BadRequestTypes.Contains(exception.GetType()))
            {
                code = HttpStatusCode.BadRequest;
            }

            else if(BadOperationTypes.Contains(exception.GetType()))
            {
                code = HttpStatusCode.Forbidden;
            }

            else if (BadNoResourceTypes.Contains(exception.GetType()))
            {
                code = HttpStatusCode.NotFound;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            data.Error += $" (Code) - {context.Response.StatusCode}";
            
            //await context.Response.WriteAsync(JsonConvert.SerializeObject(new
            //{
            //    error = new
            //    {
            //        message = exception.Message
            //    }
            //})).ConfigureAwait(false);
        }

        private static PageTracking GetData(HttpContext context)
        {
            var tracking = new PageTracking
                { CreatedAt = DateTime.Now, Method = context.Request.Method, EndPoint = context.Request.Path };

            if (context.Request.QueryString.HasValue)
            {
                tracking.EndPoint += "  {QueryString} = " + context.Request.QueryString.Value;
            }

            return tracking;
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

            foreach (var path in _logPageViewDictionary.Select(logPageViewCount => logPageViewCount.Key))
            {
                _logPageViewDictionary.TryGetValue(path, out var logPage);
                _logger.LogInformation(PageLogEventId.PageViewCount, "Path - {path}, User - {user}, Count - {count}, SignalTime {signal}", path, logPage?.UserName, logPage?.Count, e.SignalTime);
            }

            // refresh the dictionary
            // _logPageViewDictionary.Clear();
        }
    }
}
