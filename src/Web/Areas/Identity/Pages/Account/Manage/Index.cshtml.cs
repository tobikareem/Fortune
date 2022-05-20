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
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Extensions;

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

        #region Country

        public IEnumerable<SelectListItem> Countries = new List<SelectListItem>
        {
            new() { Value = "United States of America", Text = "United States of America" },
            new() { Value = "Afganistan", Text = "Afghanistan" },
            new() { Value = "Albania", Text = "Albania" },
            new() { Value = "Algeria", Text = "Algeria" },
            new() { Value = "American Samoa", Text = "American Samoa" },
            new() { Value = "Andorra", Text = "Andorra" },
            new() { Value = "Angola", Text = "Angola" },
            new() { Value = "Anguilla", Text = "Anguilla" },
            new() { Value = "Antigua & Barbuda", Text = "Antigua & Barbuda" },
            new() { Value = "Argentina", Text = "Argentina" },
            new() { Value = "Armenia", Text = "Armenia" },
            new() { Value = "Aruba", Text = "Aruba" },
            new() { Value = "Australia", Text = "Australia" },
            new() { Value = "Austria", Text = "Austria" },
            new() { Value = "Azerbaijan", Text = "Azerbaijan" },
            new() { Value = "Bahamas", Text = "Bahamas" },
            new() { Value = "Bahrain", Text = "Bahrain" },
            new() { Value = "Bangladesh", Text = "Bangladesh" },
            new() { Value = "Barbados", Text = "Barbados" },
            new() { Value = "Belarus", Text = "Belarus" },
            new() { Value = "Belgium", Text = "Belgium" },
            new() { Value = "Belize", Text = "Belize" },
            new() { Value = "Benin", Text = "Benin" },
            new() { Value = "Bermuda", Text = "Bermuda" },
            new() { Value = "Bhutan", Text = "Bhutan" },
            new() { Value = "Bolivia", Text = "Bolivia" },
            new() { Value = "Bonaire", Text = "Bonaire" },
            new() { Value = "Bosnia & Herzegovina", Text = "Bosnia & Herzegovina" },
            new() { Value = "Botswana", Text = "Botswana" },
            new() { Value = "Brazil", Text = "Brazil" },
            new() { Value = "British Indian Ocean Ter", Text = "British Indian Ocean Ter" },
            new() { Value = "Brunei", Text = "Brunei" },
            new() { Value = "Bulgaria", Text = "Bulgaria" },
            new() { Value = "Burkina Faso", Text = "Burkina Faso" },
            new() { Value = "Burundi", Text = "Burundi" },
            new() { Value = "Cambodia", Text = "Cambodia" },
            new() { Value = "Cameroon", Text = "Cameroon" },
            new() { Value = "Canada", Text = "Canada" },
            new() { Value = "Canary Islands", Text = "Canary Islands" },
            new() { Value = "Cape Verde", Text = "Cape Verde" },
            new() { Value = "Cayman Islands", Text = "Cayman Islands" },
            new() { Value = "Central African Republic", Text = "Central African Republic" },
            new() { Value = "Chad", Text = "Chad" },
            new() { Value = "Channel Islands", Text = "Channel Islands" },
            new() { Value = "Chile", Text = "Chile" },
            new() { Value = "China", Text = "China" },
            new() { Value = "Christmas Island", Text = "Christmas Island" },
            new() { Value = "Cocos Island", Text = "Cocos Island" },
            new() { Value = "Colombia", Text = "Colombia" },
            new() { Value = "Comoros", Text = "Comoros" },
            new() { Value = "Congo", Text = "Congo" },
            new() { Value = "Cook Islands", Text = "Cook Islands" },
            new() { Value = "Costa Rica", Text = "Costa Rica" },
            new() { Value = "Cote DIvoire", Text = "Cote D'Ivoire" },
            new() { Value = "Croatia", Text = "Croatia" },
            new() { Value = "Cuba", Text = "Cuba" },
            new() { Value = "Curaco", Text = "Curacao" },
            new() { Value = "Cyprus", Text = "Cyprus" },
            new() { Value = "Czech Republic", Text = "Czech Republic" },
            new() { Value = "Denmark", Text = "Denmark" },
            new() { Value = "Djibouti", Text = "Djibouti" },
            new() { Value = "Dominica", Text = "Dominica" },
            new() { Value = "Dominican Republic", Text = "Dominican Republic" },
            new() { Value = "East Timor", Text = "East Timor" },
            new() { Value = "Ecuador", Text = "Ecuador" },
            new() { Value = "Egypt", Text = "Egypt" },
            new() { Value = "El Salvador", Text = "El Salvador" },
            new() { Value = "Equatorial Guinea", Text = "Equatorial Guinea" },
            new() { Value = "Eritrea", Text = "Eritrea" },
            new() { Value = "Estonia", Text = "Estonia" },
            new() { Value = "Ethiopia", Text = "Ethiopia" },
            new() { Value = "Falkland Islands", Text = "Falkland Islands" },
            new() { Value = "Faroe Islands", Text = "Faroe Islands" },
            new() { Value = "Fiji", Text = "Fiji" },
            new() { Value = "Finland", Text = "Finland" },
            new() { Value = "France", Text = "France" },
            new() { Value = "French Guiana", Text = "French Guiana" },
            new() { Value = "French Polynesia", Text = "French Polynesia" },
            new() { Value = "French Southern Ter", Text = "French Southern Ter" },
            new() { Value = "Gabon", Text = "Gabon" },
            new() { Value = "Gambia", Text = "Gambia" },
            new() { Value = "Georgia", Text = "Georgia" },
            new() { Value = "Germany", Text = "Germany" },
            new() { Value = "Ghana", Text = "Ghana" },
            new() { Value = "Gibraltar", Text = "Gibraltar" },
            new() { Value = "Great Britain", Text = "Great Britain" },
            new() { Value = "Greece", Text = "Greece" },
            new() { Value = "Greenland", Text = "Greenland" },
            new() { Value = "Grenada", Text = "Grenada" },
            new() { Value = "Guadeloupe", Text = "Guadeloupe" },
            new() { Value = "Guam", Text = "Guam" },
            new() { Value = "Guatemala", Text = "Guatemala" },
            new() { Value = "Guinea", Text = "Guinea" },
            new() { Value = "Guyana", Text = "Guyana" },
            new() { Value = "Haiti", Text = "Gaiti" },
            new() { Value = "Hawaii", Text = "Gawaii" },
            new() { Value = "Honduras", Text = "Honduras" },
            new() { Value = "Hong Kong", Text = "Hong Kong" },
            new() { Value = "Hungary", Text = "Hungary" },
            new() { Value = "Iceland", Text = "Iceland" },
            new() { Value = "Indonesia", Text = "Indonesia" },
            new() { Value = "India", Text = "India" },
            new() { Value = "Iran", Text = "Iran" },
            new() { Value = "Iraq", Text = "raq" },
            new() { Value = "Ireland", Text = "Ireland" },
            new() { Value = "Isle of Man", Text = "Isle of Man" },
            new() { Value = "Israel", Text = "Israel" },
            new() { Value = "Italy", Text = "Italy" },
            new() { Value = "Jamaica", Text = "Jamaica" },
            new() { Value = "Japan", Text = "Japan" },
            new() { Value = "Jordan", Text = "Jordan" },
            new() { Value = "Kazakhstan", Text = "Kazakhstan" },
            new() { Value = "Kenya", Text = "Kenya" },
            new() { Value = "Kiribati", Text = "Kiribati" },
            new() { Value = "Korea North", Text = "Korea North" },
            new() { Value = "Korea Sout", Text = "Korea South" },
            new() { Value = "Kuwait", Text = "Kuwait" },
            new() { Value = "Kyrgyzstan", Text = "Kyrgyzstan" },
            new() { Value = "Laos", Text = "Laos" },
            new() { Value = "Latvia", Text = "Latvia" },
            new() { Value = "Lebanon", Text = "Lebanon" },
            new() { Value = "Lesotho", Text = "Lesotho" },
            new() { Value = "Liberia", Text = "Liberia" },
            new() { Value = "Libya", Text = "Libya" },
            new() { Value = "Liechtenstein", Text = "Liechtenstein" },
            new() { Value = "Lithuania", Text = "Lithuania" },
            new() { Value = "Luxembourg", Text = "LMuxembourg" },
            new() { Value = "Macau", Text = "Macau" },
            new() { Value = "Macedonia", Text = "Macedonia" },
            new() { Value = "Madagascar", Text = "Madagascar" },
            new() { Value = "Malaysia", Text = "Malaysia" },
            new() { Value = "Malawi", Text = "Malawi" },
            new() { Value = "Maldives", Text = "Maldives" },
            new() { Value = "Mali", Text = "Mali" },
            new() { Value = "Malta", Text = "Malta" },
            new() { Value = "Marshall Islands", Text = "Marshall Islands" },
            new() { Value = "Martinique", Text = "Martinique" },
            new() { Value = "Mauritania", Text = "Mauritania" },
            new() { Value = "Mauritius", Text = "Mauritius" },
            new() { Value = "Mayotte", Text = "Mayotte" },
            new() { Value = "Mexico", Text = "Mexico" },
            new() { Value = "Midway Islands", Text = "Midway Islands" },
            new() { Value = "Moldova", Text = "Moldova" },
            new() { Value = "Monaco", Text = "Monaco" },
            new() { Value = "Mongolia", Text = "Mongolia" },
            new() { Value = "Montserrat", Text = "Montserrat" },
            new() { Value = "Morocco", Text = "Morocco" },
            new() { Value = "Mozambique", Text = "Mozambique" },
            new() { Value = "Myanmar", Text = "Myanmar" },
            new() { Value = "Nambia", Text = "Nambia" },
            new() { Value = "Nauru", Text = "Nauru" },
            new() { Value = "Nepal", Text = "Nepal" },
            new() { Value = "Netherland Antilles", Text = "Netherland Antilles" },
            new() { Value = "Netherlands", Text = "Netherlands(Holland, Europe)" },
            new() { Value = "Nevis", Text = "Nevis" },
            new() { Value = "New Caledonia", Text = "New Caledonia" },
            new() { Value = "New Zealand", Text = "New Zealand" },
            new() { Value = "Nicaragua", Text = "Nicaragua" },
            new() { Value = "Niger", Text = "iger" },
            new() { Value = "Nigeria", Text = "Nigeria" },
            new() { Value = "Niue", Text = "Niue" },
            new() { Value = "Norfolk Island", Text = "Norfolk Island" },
            new() { Value = "Norway", Text = "Norway" },
            new() { Value = "Oman", Text = "Oman" },
            new() { Value = "Pakistan", Text = "Pakistan" },
            new() { Value = "Palau Island", Text = "Palau Island" },
            new() { Value = "Palestine", Text = "Palestine" },
            new() { Value = "Panama", Text = "Panama" },
            new() { Value = "Papua New Guinea", Text = "Papua New Guinea" },
            new() { Value = "Paraguay", Text = "Paraguay" },
            new() { Value = "Peru", Text = "Peru" },
            new() { Value = "Phillipines", Text = "Philippines" },
            new() { Value = "Pitcairn Island", Text = "Pitcairn Island" },
            new() { Value = "Poland", Text = "Poland" },
            new() { Value = "Portugal", Text = "Portugal" },
            new() { Value = "Puerto Rico", Text = "Puerto Rico" },
            new() { Value = "Qatar", Text = "Qatar" },
            new() { Value = "Republic of Montenegro", Text = "Republic of Montenegro" },
            new() { Value = "Republic of Serbia", Text = "Republic of Serbia" },
            new() { Value = "Reunion", Text = "Reunion" },
            new() { Value = "Romania", Text = "Romania" },
            new() { Value = "Russia", Text = "Russia" },
            new() { Value = "Rwanda", Text = "Rwanda" },
            new() { Value = "St Barthelemy", Text = "St Barthelemy" },
            new() { Value = "St Eustatius", Text = "St Eustatius" },
            new() { Value = "St Helena", Text = "St Helena" },
            new() { Value = "St Kitts-Nevis", Text = "St Kitts-Nevis" },
            new() { Value = "St Lucia", Text = "St Lucia" },
            new() { Value = "St Maarten", Text = "St Maarten" },
            new() { Value = "St Pierre & Miquelon", Text = "St Pierre & Miquelon" },
            new() { Value = "St Vincent & Grenadines", Text = "St Vincent & Grenadines" },
            new() { Value = "Saipan", Text = "Saipan" },
            new() { Value = "Samoa", Text = "Samoa" },
            new() { Value = "Samoa American", Text = "Samoa American" },
            new() { Value = "San Marino", Text = "San Marino" },
            new() { Value = "Sao Tome & Principe", Text = "Sao Tome & Principe" },
            new() { Value = "Saudi Arabia", Text = "Saudi Arabia" },
            new() { Value = "Senegal", Text = "Senegal" },
            new() { Value = "Seychelles", Text = "Seychelles" },
            new() { Value = "Sierra Leone", Text = "Sierra Leone" },
            new() { Value = "Singapore", Text = "Singapore" },
            new() { Value = "Slovakia", Text = "Slovakia" },
            new() { Value = "Slovenia", Text = "Slovenia" },
            new() { Value = "Solomon Islands", Text = "Solomon Islands" },
            new() { Value = "Somalia", Text = "Somalia" },
            new() { Value = "South Africa", Text = "South Africa" },
            new() { Value = "Spain", Text = "Spain" },
            new() { Value = "Sri Lanka", Text = "Sri Lanka" },
            new() { Value = "Sudan", Text = "Sudan" },
            new() { Value = "Suriname", Text = "Suriname" },
            new() { Value = "Swaziland", Text = "Swaziland" },
            new() { Value = "Sweden", Text = "Sweden" },
            new() { Value = "Switzerland", Text = "Switzerland" },
            new() { Value = "Syria", Text = "Syria" },
            new() { Value = "Tahiti", Text = "Tahiti" },
            new() { Value = "Taiwan", Text = "Taiwan" },
            new() { Value = "Tajikistan", Text = "Tajikistan" },
            new() { Value = "Tanzania", Text = "Tanzania" },
            new() { Value = "Thailand", Text = "Thailand" },
            new() { Value = "Togo", Text = "Togo" },
            new() { Value = "Tokelau", Text = "Tokelau" },
            new() { Value = "Tonga", Text = "Tonga" },
            new() { Value = "Trinidad & Tobago", Text = "Trinidad & Tobago" },
            new() { Value = "Tunisia", Text = "Tunisia" },
            new() { Value = "Turkey", Text = "Turkey" },
            new() { Value = "Turkmenistan", Text = "Turkmenistan" },
            new() { Value = "Turks & Caicos Is", Text = "Turks & Caicos Is" },
            new() { Value = "Tuvalu", Text = "Tuvalu" },
            new() { Value = "Uganda", Text = "Uganda" },
            new() { Value = "United Kingdom", Text = "United Kingdom" },
            new() { Value = "Ukraine", Text = "Ukraine" },
            new() { Value = "United Arab Erimates", Text = "United Arab Emirates" },
            new() { Value = "Uraguay", Text = "Uruguay" },
            new() { Value = "Uzbekistan", Text = "Uzbekistan" },
            new() { Value = "Vanuatu", Text = "Vanuatu" },
            new() { Value = "Vatican City State", Text = "Vatican City State" },
            new() { Value = "Venezuela", Text = "Venezuela" },
            new() { Value = "Vietnam", Text = "Vietnam" },
            new() { Value = "Virgin Islands (Brit)", Text = "Virgin Islands (Brit)" },
            new() { Value = "Virgin Islands (USA)", Text = "Virgin Islands (USA)" },
            new() { Value = "Wake Island", Text = "Wake Island" },
            new() { Value = "Wallis & Futana Is", Text = "Wallis & Futana Is" },
            new() { Value = "Yemen", Text = "Yemen" },
            new() { Value = "Zaire", Text = "Zaire" },
            new() { Value = "Zambia", Text = "Zambia" },
            new() { Value = "Zimbabwe", Text = "Zimbabwe" }
        };

        #endregion

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

            [Display(Name = "Birth Day"), Range(1, 31)]
            public int Day { get; set; }

            [Display(Name = "Birth Month"), Range(1, 12)]
            public int Month { get; set; }



            [Display(Name = "Birthday"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime Birthday { get; set; }

            [Display(Name = "Check to subscribe for email notifications")]
            public bool IsSubscribed { get; set; }

            [Display(Name = "Upload a picture")]
            public IFormFile Upload { get; set; }

            [Display(Name = "Location")]
            public string Location { get; set; }
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
                Input.Day = userDetail.Birthday.GetValueOrDefault().Day;
                Input.Month = userDetail.Birthday.GetValueOrDefault().Month;
                Input.IsSubscribed = userDetail.IsSubscribed;
                Input.Location = userDetail.Location;
                UserPhotoFileLink = UserPhotoFileLink.GetImageSrc(userDetail.ProfileImage);
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

        private async Task<byte[]> OnPostUploadFile()
        {
            var file = Input.Upload;

            if (file is null)
            {
                return (byte[])Enumerable.Empty<byte>();
            }

            #region Comment out upload to Google Drive
            //var fileTempPath = Path.GetTempPath();


            //var fileExtInd = file.FileName.LastIndexOf('.');

            //var fileExt = file.FileName[fileExtInd..];

            //var userId = _userManager.GetUserId(User);

            //var fileName = userId + fileExt;

            // check if file already exists
            //var files = await _cacheService.GetOrCreate(CacheEntry.DrivePhotos, _serviceCalls.GetAllGoogleDrivePhotosAsync, 120);

            //if (files.Any(x => x.Name == fileName))
            //{
            //    // get the file id
            //    var id = files.First(x => x.Name == fileName).Id;

            //    await _serviceCalls.DeleteFileOnGoogleDriveAsync(id);
            //}

            //  var filePath = Path.Combine(fileTempPath, fileName);

            //  var fileId = await _serviceCalls.UploadFileToGoogleDriveAsync(stream, fileName, "image/*", string.Empty, $"Friend: {fileName} uploaded.");

            //   _cacheService.Remove(CacheEntry.DrivePhotos);
            #endregion

            await using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            return stream.ToArray();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var byteImage = await OnPostUploadFile();

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            Input.Birthday = new DateTime(1990, Input.Month, Input.Day);
            // If the birthday is not set or is date time default value, then add to validation errors
            if (Input.Day != 0 && Input.Month != 0 && Input.Birthday == DateTime.MinValue)
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
            if (detail != null)
            {
                // userDetail.Id = detail.Id;
                detail.ModifiedBy = user.Id;
                detail.ModifiedOn = DateTime.UtcNow;
                detail.Title = Input.Title;
                detail.Company = Input.Company;
                detail.Birthday = Input.Birthday;
                detail.DriveFileId = string.Empty;
                detail.IsSubscribed = Input.IsSubscribed;
                detail.Location = Input.Location;
                detail.ProfileImage = byteImage;

                _userDetail.UpdateEntity(detail, CacheEntry.UserDetails, true);
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
                    DriveFileId = string.Empty,
                    IsSubscribed = Input.IsSubscribed,
                    Location = Input.Location,
                    ProfileImage = byteImage
                };

                _userDetail.AddEntity(detail, CacheEntry.UserDetails, true);
            }

            await _signInManager.RefreshSignInAsync(user);
            await LoadAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

    }
}
