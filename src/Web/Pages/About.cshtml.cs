using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Interfaces.Services;

namespace Web.Pages
{
    public class AboutModel : PageModel
    {
        private readonly IServiceCalls _calls;
        public AboutModel(IServiceCalls calls)
        {
            _calls = calls;
        }


        //public async Task<IActionResult> OnGetAsync()
        //{
        //   // await _calls.GetGoggleAnalytics();

        //    return Page();
        //}
    }
}
