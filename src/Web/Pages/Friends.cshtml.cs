using Core.Constants;
using Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Interfaces.Repository;
using Shared.Interfaces.Services;

namespace Web.Pages
{
    public class FriendsModel : PageModel
    {
        private readonly IExternalApiCalls _serviceCalls;

        private readonly ICacheService _cacheService;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IDataStore<UserDetail> _userDetail;

        public bool CanShowLink { get; set; }

        public List<DriveFiles> GoggleDriveFiles { get; set; }
        public FriendsModel(IExternalApiCalls serviceCalls, ICacheService cacheService, UserManager<ApplicationUser> userManager,IDataStore<UserDetail> userDetail)
        {
            _serviceCalls = serviceCalls;
            _cacheService = cacheService;
            _userManager = userManager;
            _userDetail = userDetail;
            GoggleDriveFiles = new List<DriveFiles>();
        }

        public async Task<IActionResult> OnGet()
        {
            var friendDetails = await PopulateFriendsDetails();

            var isUserAuthenticated = false;
            var isSameUser = false;

            // check if user is authenticated
            if (User.Identity is { IsAuthenticated: true })
            {
                isUserAuthenticated = true;
            }

            var userId = _userManager.GetUserId(User);

            if (friendDetails.FirstOrDefault(x => x.UserId == userId) != null)
            {
                isSameUser = true;
            }

            CanShowLink = !isUserAuthenticated && !isSameUser;

            return Page();
        }

        private async Task<List<UserDetail>> PopulateFriendsDetails()
        {
            var friends = _cacheService.GetOrCreate(CacheEntry.GetAllFriends, _userDetail.GetAll, 120).Where(x => x.User?.UserName != "oluwatobikareem@gmail.com").ToList();
            var files = await _cacheService.GetOrCreate(CacheEntry.DrivePhotos, _serviceCalls.GetAllGoogleDrivePhotosAsync, 120);
            
            foreach (var userDetail in friends)
            {
                var userClaims = await _userManager.GetClaimsAsync(new ApplicationUser { Id =  userDetail.UserId, UserName = userDetail?.User?.UserName });

                var firstName = userClaims.ToList().Find(x => x.Type == "FirstName")?.Value ?? string.Empty;
                var lastName = userClaims.ToList().Find(x => x.Type == "LastName")?.Value ?? string.Empty;

                GoggleDriveFiles.Add(new DriveFiles
                {
                    FullName = $"{firstName} {lastName}",
                    Birthday = userDetail?.Birthday.GetValueOrDefault(),
                    FacebookLink = userDetail?.FacebookLink,
                    TwitterLink = "https://twitter.com/" + userDetail?.TwitterLink,
                    InstagramLink = "https://www.instagram.com/" + userDetail?.InstagramLink,
                    YoutubeLink = userDetail?.YoutubeLink,
                    WebsiteUrl = userDetail?.WebsiteUrl,
                    ThumbnailLink = files.FirstOrDefault(x => x.Id == userDetail?.DriveFileId)?.ThumbnailLink ?? string.Empty,
                    FileName = firstName,
                    Title = userDetail?.Title,
                    Company = userDetail?.Company

                });
            }

            return friends;
        }


        public class DriveFiles : UserDetail
        {
            public string FullName { get; set; }
            public string FileName { get; set; }
            public string ThumbnailLink { get; set; }
        }
    }
}
