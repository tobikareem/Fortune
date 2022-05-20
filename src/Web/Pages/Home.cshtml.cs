using System.Security.Claims;
using Core.Constants;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Interfaces.Repository;
using Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces.Services;
using SpotifyAPI.Web;

namespace Web.Pages
{
    public class HomeModel : PageModel
    {
        private readonly ILogger<HomeModel> _logger;
        private readonly IDataStore<Post> _dataPost;
        private readonly ICacheService _cacheService;
        private readonly IUserService _userService;
        private readonly IExternalApiCalls _serviceCalls;
        public bool IsTobiKareem { get; set; }
        public List<CustomPost> DisplayPosts { get; set; }

        

        public HomeModel(IDataStore<Post> dataStore, ILogger<HomeModel> logger, ICacheService cacheService, IUserService userService, IExternalApiCalls serviceCalls)
        {
            _logger = logger;
            _dataPost = dataStore;
            _cacheService = cacheService;
            _userService = userService;
            _serviceCalls = serviceCalls;
            DisplayPosts = new List<CustomPost>();
        }

        public async Task<IActionResult> OnGet()
        {
            IsTobiKareem = User.HasClaim(ClaimTypes.Role, ResourceAction.FortuneAdmin);

            var posts = _cacheService.GetOrCreate(CacheEntry.Posts, _dataPost.GetAll, 180);
            var mindFeeds = posts.Where(x => string.Compare(x.Category?.Category1, "mindfeed", StringComparison.CurrentCultureIgnoreCase) == 0 && x.Enabled).ToList();

            if (!mindFeeds.Any())
            {
                return Page();
            }

            _logger.Log(LogLevel.Information, PageLogEventId.GeneralInformationCount, ".... Got a count list of mind feeds: {mindFeeds} post(s) by me", mindFeeds.Count);
            var cPosts = mindFeeds.OrderByDescending(x => x.Id).ToList();

            DisplayPosts.AddRange(cPosts.Select(x => new CustomPost
            {
                Title = x.Title,
                Id = x.Id,
                CreatedOn = x.CreatedOn
                
            }));

            var spotifyPost = await GetSpotifyMusicInfo();

            if (!string.IsNullOrWhiteSpace(spotifyPost.SpotifyPreviewSong))
            {

                DisplayPosts.Insert(0,
                    new CustomPost
                    {
                        SpotifyPreviewSong = spotifyPost.SpotifyPreviewSong,
                        SpotifySongName = spotifyPost.SpotifySongName,
                        SpotifyExternalUrl = spotifyPost.SpotifyExternalUrl,
                        SpotifyArtistName = spotifyPost.SpotifyArtistName,
                        SpotifySongImage = spotifyPost.SpotifySongImage
                    });
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            _logger.Log(LogLevel.Information, PageLogEventId.GeneralInformationCount, ".... Redirecting to contact from Home page");
            return RedirectToPage("/Contact");
        }

        private async Task<CustomPost> GetSpotifyMusicInfo()
        {
            var customPost = new CustomPost();
            try
            {
                var user = await _userService.GetTobiKareemUserAsync(); //_userService.GetCurrentUserId(User);

                var spotify = await _serviceCalls.SpotifyClientBuilderAsync(user);

                // var me = await spotify.UserProfile.Current();

                var currentlyPlaying = await spotify.Player.GetCurrentlyPlaying(new PlayerCurrentlyPlayingRequest
                {
                    Market = "US"
                });
                
                if (currentlyPlaying != null && currentlyPlaying.Item is FullTrack item)
                {
                    customPost = new CustomPost
                    {
                        SpotifySongName = item.Name,
                        SpotifyPreviewSong = item.PreviewUrl,
                        SpotifyExternalUrl = item.ExternalUrls.First(x => x.Key == "spotify").Value,
                        SpotifyArtistName = item.Artists.First().Name,
                        SpotifySongImage = item.Album.Images.Last().Url

                    };
                }

            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, PageLogEventId.ApiCallFailed, ".... Error getting spotify info: {error}", e.Message);
            }

            return customPost;
        }

        public class CustomPost:Post
        {
            public string SpotifySongName { get; set; }
            public string SpotifyPreviewSong { get; set; }
            public string SpotifyExternalUrl { get; set; }
            public string SpotifySongImage { get; set; }
            public string SpotifyArtistName { get; set; }
        }
    }
}
