using Core.Constants;
using Shared.Interfaces.Repository;
using Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Shared.Interfaces.Services;
using Comment = Core.Models.Comment;
using Post = Core.Models.Post;

namespace Web.Pages
{
    public class BlogPostModel : PageModel
    {

        private readonly IDataStore<Data.Entity.Post> _blogPostRepo;
        private readonly IDataStore<UserDetail> _userDetail;        
        private readonly IExternalApiCalls _serviceCalls;
        private readonly ICacheService _cacheService;
        
        [BindProperty] public Comment CommentUser { get; set; }

        public BlogPostClass BlogPost { get; set; }

        public BlogPostModel(IDataStore<Data.Entity.Post> blogPostRepo, IExternalApiCalls serviceCalls, ICacheService cacheService, IDataStore<UserDetail> userDetail)
        {
            _blogPostRepo = blogPostRepo;
            _serviceCalls = serviceCalls;
            _cacheService = cacheService;
            _userDetail = userDetail;

            CommentUser = new Comment();
            BlogPost = new BlogPostClass();
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var friends = _cacheService.GetOrCreate(CacheEntry.GetAllFriends, _userDetail.GetAll, 120).ToList();
            var files = await _cacheService.GetOrCreate(CacheEntry.DrivePhotos, _serviceCalls.GetAllGoogleDrivePhotosAsync, 120);

            var blog = _blogPostRepo.GetById(id);
            var createdByUserId = blog.UserId;
            
            BlogPost = new BlogPostClass
            {
                CreatedBy = blog.CreatedBy,
                CreatedOn = blog.CreatedOn,
                Description = blog.Description,
                Content = blog.Content
            };

            var driveFileId = friends.FirstOrDefault(x => x.UserId == createdByUserId)?.DriveFileId;
            if (driveFileId == null) return Page();
            {
                var file = files.FirstOrDefault(x => x.Id == driveFileId)?.ThumbnailLink;

                if (file != null)
                {
                    BlogPost.ImageThumbNail = file;
                }
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            return Page();
        }

        public class BlogPostClass: Post
        {
            public string ImageThumbNail { get; set; }
            
        }
    }
}
