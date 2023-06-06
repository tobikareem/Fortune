using System.Diagnostics;
using System.Globalization;
using Core.Configuration;
using Core.Constants;
using Core.Models;
using Data.Entity;
using Google.Apis.Analytics.v3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using Shared.Interfaces.Repository;
using Shared.Interfaces.Services;
using SpotifyAPI.Web;
using File = Google.Apis.Drive.v3.Data.File;

namespace Shared.Services
{
    public class ExternalApiCalls : IExternalApiCalls
    {
        private readonly GoogleDriveApi _googleDriveApi;
        private readonly GoogleAnalytics _googleAnalytics;
        private readonly EmailProp _emailProp;
        private readonly SingleProperty _singleProp;
        private readonly IHttpRepository _httpRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SpotifyClientConfig _spotifyClientConfig;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ExternalApiCalls> _logger;


        public ExternalApiCalls(IOptions<GoogleDriveApi> driveConfig, IOptions<GoogleAnalytics> analyticsConfig,
            IOptions<EmailProp> emailConfig, IOptions<SingleProperty> singleProp, IHttpRepository httpRepository, ILogger<ExternalApiCalls> logger,
            IHttpContextAccessor httpContextAccessor, SpotifyClientConfig spotifyClientConfig, UserManager<ApplicationUser> userManager)
        {
            _googleDriveApi = driveConfig.Value;
            _googleAnalytics = analyticsConfig.Value;
            _emailProp = emailConfig.Value;
            _singleProp = singleProp.Value;
            _httpRepository = httpRepository;
            _httpContextAccessor = httpContextAccessor;
            _spotifyClientConfig = spotifyClientConfig;
            _logger = logger;
            _userManager = userManager;
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

        public async Task<TweetData> GetAllMyTweetsAsync()
        {
            var tweets = await _httpRepository.GetMyTweetsAsync();

            Debug.Assert(tweets != null, nameof(tweets) + " != null");
            return tweets;
        }

        public async Task<List<AnalyticsData>> GetGoogleAnalyticsAsync()
        {
            var service = GetAnalyticsServiceAsync();

            var dataResource = service.Data.Ga.Get("ga:" + "120002390", "30daysAgo", "today", "ga:users,ga:sessions");

            dataResource.Dimensions = "ga:browser,ga:operatingSystem,ga:mobileDeviceInfo,ga:country,ga:region";

            var response = await dataResource.ExecuteAsync();


            var analysis = response.Rows.Select(row => new AnalyticsData
            {
                // get the first item of ro
                Browser = row[0],
                OperatingSystem = row[1],
                MobileDeviceInfo = row[2],
                Country = row[3],
                Region = row[4],
                UserCount = int.Parse(row[5]),
                SessionCount = int.Parse(row[6])
            })
                .ToList();

            return analysis;

            //// Initialize request argument(s)
            //var request = new RunReportRequest
            //{
            //    Property = "properties/" + propertyId,
            //    Dimensions = { new Dimension { Name = "city" }, },
            //    Metrics = { new Metric { Name = "activeUsers" }, },
            //    DateRanges = { new DateRange { StartDate = "2022-03-31", EndDate = "today" }, },
            //};

            //// Make the request
            ////var response = await client.RunReportAsync(request);

            //Console.WriteLine("Report result:");
            //foreach (var row in response.Rows)
            //{
            //    Console.WriteLine("{0}, {1}", row.DimensionValues[0].Value, row.MetricValues[0].Value);
            //}
        }

        public async Task<List<File>> GetAllGoogleDrivePhotosAsync()
        {
            var service = await GetServiceAsync();

            // Define parameters of request.
            var listRequest = service.Files.List();
            listRequest.Spaces = "drive";
            listRequest.PageSize = 50;
            listRequest.Fields = "nextPageToken, files(id, name, thumbnailLink, originalFilename, webViewLink)";

            // List files.
            var files = await listRequest.ExecuteAsync();
            return files.Files.ToList();
        }

        public async Task<string> UploadFileToGoogleDriveAsync(Stream file, string fileName, string fileMime, string folder, string fileDescription)
        {
            var service = await GetServiceAsync();


            var driveFile = new File
            {
                Name = fileName,
                OriginalFilename = fileName,
                Description = fileDescription,
                MimeType = string.IsNullOrWhiteSpace(fileMime) ? GoogleApis.MimeType : fileMime,
            };

            if (!string.IsNullOrWhiteSpace(folder))
            {
                driveFile.Parents = new[] { folder };
            }


            var request = service.Files.Create(driveFile, file, fileMime);
            request.Fields = "id";

            var response = await request.UploadAsync();

            if (response.Status != Google.Apis.Upload.UploadStatus.Completed)
                throw response.Exception;

            return request.ResponseBody.Id;
        }

        public async Task<string> CreateFolderOnGoogleDriveAsync(string parent, string folderName)
        {
            var service = await GetServiceAsync();
            var driveFolder = new File
            {
                Name = folderName,
                MimeType = "application/vnd.google-apps.folder",
                Parents = new[] { parent }
            };
            var command = service.Files.Create(driveFolder);
            var file = await command.ExecuteAsync();
            return file.Id;
        }

        public async Task DeleteFileOnGoogleDriveAsync(string fileId)
        {
            var service = await GetServiceAsync();
            var command = service.Files.Delete(fileId);
            _ = await command.ExecuteAsync();
        }

        public async Task<SpotifyClient> SpotifyClientBuilderAsync(ApplicationUser user)
        {
            var client = new SpotifyClient("");
            try
            {
                if (_httpContextAccessor.HttpContext != null)
                {
                    var token = await _userManager.GetAuthenticationTokenAsync(user, "Spotify", "access_token");
                    var refreshToken = await _userManager.GetAuthenticationTokenAsync(user, "Spotify", "refresh_token");
                    var expireTime = await _userManager.GetAuthenticationTokenAsync(user, "Spotify", "expires_in");

                    DateTime.TryParse(expireTime, out var isExpired);
                    
                    if (isExpired == DateTime.MinValue || isExpired < DateTime.Now)
                    {
                        var accessBearer = await _httpRepository.GetSpotifyAccessTokenAsync(refreshToken);
                        
                        var expiryTime = DateTime.Now.AddSeconds(accessBearer.ExpiresIn);
                        await SetAspNetUserTokenAsync(user, "Spotify", accessBearer.AccessToken, expiryTime.ToString(CultureInfo.CurrentCulture));

                        token = accessBearer.AccessToken;
                    }

                    var clientConfig = _spotifyClientConfig.WithToken(token);
                    client =  new SpotifyClient(clientConfig);

                }
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, PageLogEventId.MakingAnApiCall, "Error making an api call for Spotify - {message}", e.Message);
            }

            return client;
        }

        private async Task SetAspNetUserTokenAsync(ApplicationUser user, string provider, string newAccessToken, string expiresIn)
        {
            if (!string.IsNullOrWhiteSpace(newAccessToken))
            {
                await _userManager.SetAuthenticationTokenAsync(user, provider, "access_token", newAccessToken);
            }
            
            if (!string.IsNullOrWhiteSpace(expiresIn))
            {
                await _userManager.SetAuthenticationTokenAsync(user, provider, "expires_in", expiresIn);
            }
        }

        private async Task<DriveService> GetServiceAsync()
        {
            var tokenResponse = new TokenResponse
            {
                AccessToken = await _httpRepository.GetGoogleDriveAccessToken(),
                RefreshToken = _googleDriveApi.Refreshtoken,
            };


            var applicationName = _singleProp.ProjectName;
            var username = _singleProp.MyGoogleEmail;


            var apiCodeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = _googleDriveApi.OauthclientId,
                    ClientSecret = _googleDriveApi.Oauthclientsecret,
                },
                Scopes = new[] { DriveService.Scope.Drive },
                DataStore = new FileDataStore(applicationName)
            });


            var credential = new UserCredential(apiCodeFlow, username, tokenResponse);


            var service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = applicationName
            });
            return service;
        }

        private AnalyticsService GetAnalyticsServiceAsync()
        {
            var xCred = new ServiceAccountCredential(
                new ServiceAccountCredential.Initializer(_googleAnalytics.Clientemail)
                {
                    Scopes = new[]
                    {
                        AnalyticsService.Scope.AnalyticsReadonly, AnalyticsService.Scope.AnalyticsManageUsersReadonly
                    }
                }.FromPrivateKey(_googleAnalytics.Privatekey));

            var service = new AnalyticsService(new BaseClientService.Initializer
            {
                HttpClientInitializer = xCred,

                ApplicationName = _singleProp.ProjectName
            });

            return service;
        }
    }
}
