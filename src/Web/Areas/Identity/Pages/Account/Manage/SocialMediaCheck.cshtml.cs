#nullable disable
using System.ComponentModel.DataAnnotations;
using Core.Constants;
using Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shared.Interfaces.Repository;

namespace Web.Areas.Identity.Pages.Account.Manage
{
    public class SocialMediaCheckModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<SocialMediaCheckModel> _logger;
        private readonly IDataStore<UserDetail> _userDetail;

        [BindProperty]
        public UserDetailModel UserDetail { get; set; }
        
        [TempData]
        public string StatusMessage { get; set; }

        public SocialMediaCheckModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IDataStore<UserDetail> userDetail, ILogger<SocialMediaCheckModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userDetail = userDetail;
            _logger = logger;

            UserDetail = new UserDetailModel();
        }

        private UserDetail GetUserDetail(string userId)
        {
            var user = _userDetail.GetByUserId(userId).FirstOrDefault();
            return user;
        }

        private void LoadContent(ApplicationUser user)
        {
            var userDetail = GetUserDetail(user.Id);

            if (userDetail == null) return;

            UserDetail.WebsiteUrl = userDetail.WebsiteUrl;
            UserDetail.YoutubeLink = userDetail.YoutubeLink;
            UserDetail.FacebookLink = userDetail.FacebookLink;
            UserDetail.TwitterLink = userDetail.TwitterLink;
            UserDetail.InstagramLink = userDetail.InstagramLink;
            UserDetail.LinkedInLink = userDetail.LinkedInLink;

        }
        
        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                _logger.LogWarning(PageLogEventId.ApiCallFailed, "Unable to load user with ID '{UserId}'.", _userManager.GetUserId(User));
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            LoadContent(user);

            return Page();
        }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || !ModelState.IsValid)
            {
                LoadContent(user);
                return Page();
            }

            var detail = GetUserDetail(user.Id);
            if (detail != null)
            {
                // userDetail.Id = detail.Id;
                detail.WebsiteUrl = UserDetail.WebsiteUrl;
                detail.FacebookLink = UserDetail.FacebookLink;
                detail.TwitterLink = UserDetail.TwitterLink;
                detail.InstagramLink = UserDetail.InstagramLink;
                detail.LinkedInLink = UserDetail.LinkedInLink;
                detail.YoutubeLink = UserDetail.YoutubeLink;
                detail.ModifiedBy = user.Id;
                detail.ModifiedOn = DateTime.UtcNow;

                _userDetail.UpdateEntity(detail);
                StatusMessage = "Information updated successfully";
            }
            else
            {
                detail = new UserDetail
                {
                    WebsiteUrl = UserDetail.WebsiteUrl,
                    FacebookLink = UserDetail.FacebookLink,
                    TwitterLink = UserDetail.TwitterLink,
                    InstagramLink = UserDetail.InstagramLink,
                    LinkedInLink = UserDetail.LinkedInLink,
                    YoutubeLink = UserDetail.YoutubeLink,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = user.Id,
                    Enabled = true,
                    User = user
                };

                _userDetail.AddEntity(detail);
                StatusMessage = "Information saved successfully";

            }

            return RedirectToPage();
        }

        public class UserDetailModel
        {

            [Url]
            [Display(Name = "Have a website?")]
            public string WebsiteUrl { get; set; }

            [Url]
            [Display(Name = "Have a Youtube channel?")]
            public string YoutubeLink { get; set; }

            [Display(Name = "Have a Facebook Account Name?")]
            public string FacebookLink { get; set; }

            [Display(Name = "Have a Twitter Account Name?")]
            public string TwitterLink { get; set; }

            [Display(Name = "Have an Instagram Account?")]
            public string InstagramLink { get; set; }

            [Url]
            [Display(Name = "Have a LinkedIn URL?")]
            public string LinkedInLink { get; set; }
        }
    }
}
