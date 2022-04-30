// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Core.Constants;
using Shared.Interfaces.Repository;
using Shared.Interfaces.Services;

namespace Web.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IDataStore<UserDetail> _userDetail;

        private readonly ICacheService _cacheService;

        private readonly IExternalApiCalls _serviceCalls;

        public string UserPhotoFileLink { get; set; }

        public IndexModel(
            UserManager<ApplicationUser> userManager, ICacheService cacheService,
            SignInManager<ApplicationUser> signInManager, IDataStore<UserDetail> userDetail, IExternalApiCalls serviceCalls)
        {
            _userManager = userManager;
            _cacheService = cacheService;
            _signInManager = signInManager;
            _userDetail = userDetail;
            _serviceCalls = serviceCalls;

            Input = new InputModel();

        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Job Title, Career field or aspiration")]
            public string Title { get; set; }

            [Display(Name = "Company, School, Industry")]
            public string Company { get; set; }

            [Display(Name = "Birthday"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime Birthday { get; set; }

            [Display(Name = "Check to subscribe for email notifications")]
            public bool IsSubscribed { get; set; }
            public IFormFile Upload { get; set; }
        }
        private UserDetail GetUserDetail(string userId)
        {
            var user = _userDetail.GetByUserId(userId).FirstOrDefault();
            return user;
        }   

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            var userDetail = GetUserDetail(user.Id);
            
            Username = userName;
            
            if (userDetail != null)
            {
                Input.Company = userDetail.Company;
                Input.Title = userDetail.Title;
                Input.Birthday = userDetail.Birthday.GetValueOrDefault();
                Input.IsSubscribed = userDetail.IsSubscribed;

                var files = await _cacheService.GetOrCreate(CacheEntry.DrivePhotos, _serviceCalls.GetAllGoogleDrivePhotosAsync, 120);
                var file = files.FirstOrDefault(x => x.Id == userDetail.DriveFileId);
                if (file != null)
                {
                    UserPhotoFileLink = file.ThumbnailLink;
                }
            }

            if (string.IsNullOrWhiteSpace(Input.PhoneNumber))
            {
                Input.PhoneNumber = phoneNumber;
            }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        private async Task<string> OnPostUploadFile()
        {
            var file = Input.Upload;

            if (file is null)
            {
                return string.Empty;
            }

            var fileTempPath = Path.GetTempPath();

            
            var fileExtInd = file.FileName.LastIndexOf('.');
            
            var fileExt = file.FileName[fileExtInd..];

            var userId = _userManager.GetUserId(User);
            
            var fileName = userId + fileExt;

            // check if file already exists
            var files = await _cacheService.GetOrCreate(CacheEntry.DrivePhotos, _serviceCalls.GetAllGoogleDrivePhotosAsync, 120);

            if (files.Any(x => x.Name == fileName))
            {
                // get the file id
                var id = files.First(x => x.Name == fileName).Id;

                await _serviceCalls.DeleteFileOnGoogleDriveAsync(id);
            }

            var filePath = Path.Combine(fileTempPath, fileName);

            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);


           var fileId = await _serviceCalls.UploadFileToGoogleDriveAsync(stream, fileName, "image/*", string.Empty, $"Friend: {fileName} uploaded.");

           _cacheService.Remove(CacheEntry.DrivePhotos);

           return fileId;
        }

        public async Task<IActionResult> OnPostAsync()
        {

           var fileId = await OnPostUploadFile();
            
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            // If the birthday is not set or is date time default value, then add to validation errors
            if (Input.Birthday == DateTime.MinValue)
            {
                ModelState.AddModelError(string.Empty, "Birthday is not valid.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            

            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            var detail = GetUserDetail(user.Id);
            if ( detail != null)
            {
                // userDetail.Id = detail.Id;
                detail.ModifiedBy = user.Id;
                detail.ModifiedOn = DateTime.UtcNow;
                detail.Title = Input.Title;
                detail.Company = Input.Company;
                detail.Birthday = Input.Birthday;
                detail.DriveFileId = string.IsNullOrWhiteSpace(fileId) ? detail.DriveFileId : fileId;
                detail.IsSubscribed = Input.IsSubscribed;

                _userDetail.UpdateEntity(detail);
            }
            else
            {
                detail = new UserDetail
                {
                    Title = Input.Title,
                    Company = Input.Company,
                    Birthday = Input.Birthday,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = user.Id,
                    Enabled = true,
                    User = user,
                    DriveFileId = fileId,
                    IsSubscribed = Input.IsSubscribed
                };

                _userDetail.AddEntity(detail);
            }

            await _signInManager.RefreshSignInAsync(user);
            await LoadAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
        
    }
}
