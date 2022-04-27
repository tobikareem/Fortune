using System.Security.Claims;
using Core.Constants;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Interfaces.Repository;
using Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces.Services;

namespace Web.Pages
{
    public class HomeModel : PageModel
    {
        private readonly ILogger<HomeModel> _logger;
        private readonly IDataStore<Post> _dataPost;
        private readonly ICacheService _cacheService;

        public bool IsTobiKareem { get; set; }
        public List<Post> DisplayPosts { get; set; }

        public HomeModel(IDataStore<Post> dataStore, ILogger<HomeModel> logger, ICacheService cacheService)
        {
            _dataPost = dataStore;
            _logger = logger;
            _cacheService = cacheService;

            DisplayPosts = new List<Post>();
        }

        public void OnGet()
        {
            IsTobiKareem = User.HasClaim(ClaimTypes.Role, ResourceAction.FortuneAdmin);
            
            var posts = _cacheService.GetOrCreate(CacheEntry.GetAllPosts, _dataPost.GetAll, 180);
            var mindFeeds = posts.Where(x => string.Compare(x.Category.Category1, "mindfeed", StringComparison.CurrentCultureIgnoreCase) == 0 && x.Enabled).ToList();

            if (!mindFeeds.Any())
            {
                return;
            }

            _logger.Log(LogLevel.Information, PageLogEventId.GeneralInformationCount, ".... Got a count list of mind feeds: {mindFeeds} post(s) by me", mindFeeds.Count);
            DisplayPosts = mindFeeds.OrderByDescending(x => x.Id).ToList();
        }

        public IActionResult OnPost()
        {
            _logger.Log(LogLevel.Information, PageLogEventId.GeneralInformationCount, ".... Redirecting to contact from Home page");
            return RedirectToPage("/Contact");
        }
    }
}
