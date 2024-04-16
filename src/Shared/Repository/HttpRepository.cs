using System.Net.Http.Headers;
using System.Text;
using Core.Configuration;
using Core.Constants;
using Core.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shared.Interfaces.Repository;
using Shared.Interfaces.Services;
using Tweetinvi.Models;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Shared.Repository
{
    public class HttpRepository : IHttpRepository
    {
        private readonly ICacheService _cache;
        private readonly ILogger<HttpRepository> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly GoogleDriveApi _driveApiConfig;
        private readonly TwitterSignIn _twitterSignInConfig;
        private readonly Spotify _spotifyConfig;
        public HttpRepository(ICacheService cache, ILogger<HttpRepository> logger, IHttpClientFactory httpClientFactory, IOptions<GoogleDriveApi> googleAnalytics, IOptions<TwitterSignIn> tweet, IOptions<Spotify> spotify)
        {
            _cache = cache;
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _driveApiConfig = googleAnalytics.Value;
            _twitterSignInConfig = tweet.Value;
            _spotifyConfig = spotify.Value;
        }

        public async Task<string> GetGoogleDriveAccessToken()
        {
            var token = await _cache.GetOrCreate(CacheEntry.GoogleDriveAccessToken, GetBearerTokenAsync, 60);
            return token;

        }

        public async Task<TweetData?> GetMyTweetsAsync()
        {

            _ = new ConsumerOnlyCredentials(_twitterSignInConfig.Twitterconsumerkey,
                _twitterSignInConfig.Twitterconsumersecret)
            {
                BearerToken = _twitterSignInConfig.TwitterBearer
            };



            TweetData? tweetData;
            var client = _httpClientFactory.CreateClient("Tweets");
            client.DefaultRequestHeaders.Add("cache-control", "no-cache");
            client.DefaultRequestHeaders.Add("accept", "application/json");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _twitterSignInConfig.TwitterBearer);

            var response = await client.GetAsync($"https://api.twitter.com/2/users/{_twitterSignInConfig.UserId}/tweets", CancellationToken.None);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                tweetData = JsonConvert.DeserializeObject<TweetData>(responseContent);
            }
            else
            {
                throw new Exception("Tweeter call Failed" + JsonConvert.SerializeObject(response), new Exception(response.ReasonPhrase));
            }

            return tweetData;
        }

        public async Task<AccessBearerToken> GetSpotifyAccessTokenAsync(string refreshToken)
        {
            var accessBearerToken = new AccessBearerToken();

            _logger.Log(LogLevel.Information, PageLogEventId.MakingAnApiCall, "Making an API call to get the bearer token");

            var client = _httpClientFactory.CreateClient("Bearer_Token");
            client.DefaultRequestHeaders.Add("cache-control", "no-cache");

            // Add authorization header for base64 encoded clientId:clientSecret
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_spotifyConfig.ClientId}:{_spotifyConfig.ClientSecret}")));

            var response = await client.PostAsync("https://accounts.spotify.com/api/token", new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"grant_type", "refresh_token"},
                    {"refresh_token", refreshToken},
                    {"client_id", _spotifyConfig.ClientId},
                }), CancellationToken.None);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                accessBearerToken = JsonConvert.DeserializeObject<AccessBearerToken>(responseContent) ?? new AccessBearerToken();
            }
            else
            {
                _logger.Log(LogLevel.Error, PageLogEventId.ApiCallFailed, "Bearer Token call for Spotify Failed -  {Reason} - {response}", response.ReasonPhrase, JsonConvert.SerializeObject(response));
            }


            return accessBearerToken;
        }

        private async Task<string> GetBearerTokenAsync()
        {
            AccessBearerToken accessBearerToken;
            _logger.Log(LogLevel.Information, PageLogEventId.MakingAnApiCall, "Making an API call to get the bearer token");

            var client = _httpClientFactory.CreateClient("Bearer_Token");
            client.DefaultRequestHeaders.Add("cache-control", "no-cache");
            client.DefaultRequestHeaders.Add("accept", "application/json");

            var content =
                $"client_id={_driveApiConfig.OauthclientId}&client_secret={_driveApiConfig.Oauthclientsecret}&refresh_token={_driveApiConfig.Refreshtoken}&grant_type=refresh_token&scope={_driveApiConfig.Googledrivescope}";


            var response = await client.PostAsync($"{_driveApiConfig.GoogledriveTokenRequestUrl}", new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded"));

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                accessBearerToken = JsonConvert.DeserializeObject<AccessBearerToken>(responseContent) ?? new AccessBearerToken();
            }
            else
            {
                _logger.Log(LogLevel.Error, PageLogEventId.ApiCallFailed, "Failed to get the bearer token" + "Reason: " + response.ReasonPhrase);
                _logger.Log(LogLevel.Error, PageLogEventId.ApiCallFailed, "Failed to get the bearer token" + "Reason: " + JsonConvert.SerializeObject(response));
                throw new Exception("Failed to get the bearer token, Object = " + JsonConvert.SerializeObject(response), new Exception(response.ReasonPhrase));
            }

            return accessBearerToken.AccessToken;
        }
    }
}
