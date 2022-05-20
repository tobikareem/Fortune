using System.Security.Claims;
using Core.Configuration;
using Core.Constants;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Shared.Interfaces.Services;
using SpotifyAPI.Web;

namespace Web.Pages
{
    public class AboutModel : PageModel
    {
        private readonly IExternalApiCalls _serviceCalls;
        private readonly ICacheService _cacheService;
        private readonly IUserService _userService;

        public List<Datum> AllTweets { get; set; }

        public AboutModel(IExternalApiCalls serviceCalls, ICacheService cacheService, IUserService userService)
        {
            _serviceCalls = serviceCalls;
            _cacheService = cacheService;
            _userService = userService;
            AllTweets = new List<Datum>();
        }


        public IActionResult OnGet()
        {
            #region Some WIP code to get tweets from the API

            //var access = _cacheService.GetItem<string>(CacheEntry.SpotifyAccessCode);
            //if (User.HasClaim(ClaimTypes.Role, ResourceAction.FortuneAdmin) && string.IsNullOrWhiteSpace(access))
            //{
            //    var loginRequest = new LoginRequest(
            //        new Uri(_spotifyConfig.RedirectUri),
            //        _spotifyConfig.ClientId,
            //        LoginRequest.ResponseType.Code
            //    )
            //    {
            //        Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative, Scopes.Streaming, Scopes.UserFollowRead, Scopes.UserLibraryRead, Scopes.UserReadCurrentlyPlaying, Scopes.UserTopRead }
            //    };
            //    var uri = loginRequest.ToUri();

            //    return Redirect(uri.ToString());
            //}


            //var token = await _serviceCalls.GetSpotifyAccessToken();
            //var tweets = await _serviceCalls.GetAllMyTweetsAsync();

            //AllTweets = tweets.Data;

            //var result = await _serviceCalls.GetGoogleAnalyticsAsync();

            //var userCount = result.Count(x => x.UserCount > 0);
            //var sessionCount = result.Count(x => x.SessionCount > 0);

            //var count = result.GroupBy(x => x.Country).OrderBy(x => x.Key)
            //    .Select(x => new { Country = x.Key, Count = x.Count() }).ToList();

            #endregion
            
            return Page();
        }
    }

}