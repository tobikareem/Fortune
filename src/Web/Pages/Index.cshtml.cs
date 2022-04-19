using System.Diagnostics;
using Core.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configRoot)
        {
            _logger = logger;
            _configuration = configRoot;
        }

        public IActionResult OnGet()
        {
            _logger.Log(LogLevel.Information, PageLogEventId.PageLoad,"... Index page loaded");

            var str = "";

            //var defaultConn = _configuration["ConnectionStrings:DefaultConnection"];
            
            //Debug.WriteLine("App Settings Config: " + defaultConn);
            
            
            return Page();
        }
    }
}