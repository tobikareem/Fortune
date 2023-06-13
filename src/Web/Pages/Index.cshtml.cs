using Core.Constants;
using Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Interfaces.Repository;
using Shared.Interfaces.Services;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDataStore<Post> _dataPost;
        private readonly ICacheService _cacheService;

        public IndexModel(ICacheService cacheService, IDataStore<Post> dataPost)
        {
            _cacheService = cacheService;
            _dataPost = dataPost;
        }
        
        public IActionResult OnGet()
        {
           _ = _cacheService.GetOrCreate(CacheEntry.Posts, _dataPost.GetAll, 180);
            return Page();
        }
    }
}