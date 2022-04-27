// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Interfaces.Repository;

namespace Web.Areas.Identity.Pages.Account.Manage
{
    public class TwoFactorAuthenticationModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<TwoFactorAuthenticationModel> _logger;
        private readonly IDataStore<UserDetail> _userDetail;

        public TwoFactorAuthenticationModel(
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IDataStore<UserDetail> userDetail, ILogger<TwoFactorAuthenticationModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userDetail = userDetail;
            _logger = logger;

            Input = new InputModel();
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public bool HasAuthenticator { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public int RecoveryCodesLeft { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public bool Is2faEnabled { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public bool IsMachineRemembered { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {

            [Url]
            [Display(Name = "Have a website?")]
            public string? WebsiteUrl { get; set; }

            [Url]
            [Display(Name = "Have a Youtube channel?")]
            public string? YoutubeLink { get; set; }

            [Display(Name = "Have a Facebook Account Name?")]
            public string? FacebookLink { get; set; }

            [Display(Name = "Have a Twitter Account Name?")]
            public string? TwitterLink { get; set; }

            [Display(Name = "Have an Instagram Account?")]
            public string? InstagramLink { get; set; }

            [Url]
            [Display(Name = "Have a LinkedIn URL?")]
            public string? LinkedInLink { get; set; }
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

            Input.WebsiteUrl = userDetail.WebsiteUrl;
            Input.YoutubeLink = userDetail.YoutubeLink;
            Input.FacebookLink = userDetail.FacebookLink;
            Input.TwitterLink = userDetail.TwitterLink;
            Input.InstagramLink = userDetail.InstagramLink;
            Input.LinkedInLink = userDetail.LinkedInLink;

        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            LoadContent(user);


            HasAuthenticator = await _userManager.GetAuthenticatorKeyAsync(user) != null;
            Is2faEnabled = await _userManager.GetTwoFactorEnabledAsync(user);
            IsMachineRemembered = await _signInManager.IsTwoFactorClientRememberedAsync(user);
            RecoveryCodesLeft = await _userManager.CountRecoveryCodesAsync(user);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await _signInManager.ForgetTwoFactorClientAsync();
            StatusMessage = "The current browser has been forgotten. When you login again from this browser you will be prompted for your 2fa code.";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSocial()
        {
            var user = await _userManager.GetUserAsync(User);

            if (!ModelState.IsValid)
            {
                LoadContent(user);
                return Page();
            }            

            var detail = GetUserDetail(user.Id);
            if (detail != null)
            {
                // userDetail.Id = detail.Id;
                detail.WebsiteUrl = Input.WebsiteUrl;
                detail.FacebookLink = Input.FacebookLink;
                detail.TwitterLink = Input.TwitterLink;
                detail.InstagramLink = Input.InstagramLink;
                detail.LinkedInLink = Input.LinkedInLink;
                detail.YoutubeLink = Input.YoutubeLink;
                detail.ModifiedBy = user.Id;
                detail.ModifiedOn = DateTime.UtcNow;

                _userDetail.UpdateEntity(detail);
            }
            else
            {
                detail = new UserDetail
                {
                    WebsiteUrl = Input.WebsiteUrl,
                    FacebookLink = Input.FacebookLink,
                    TwitterLink = Input.TwitterLink,
                    InstagramLink = Input.InstagramLink,
                    LinkedInLink = Input.LinkedInLink,
                    YoutubeLink = Input.YoutubeLink,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = user.Id,
                    Enabled = true,
                    User = user
                };

                _userDetail.AddEntity(detail);
            }

            return RedirectToPage();

        }
    }
}
