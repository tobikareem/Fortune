using Core.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Interfaces.Services;

namespace Web.Pages
{
    public class CallbackModel : PageModel
    {
        private ICacheService _cacheService;
        public CallbackModel(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        public IActionResult OnGet(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) return RedirectToPage("/Home");
            
            _cacheService.Add(CacheEntry.SpotifyAccessCode, code, 1440);
            return RedirectToPage("/Home");

        }
    }
}
