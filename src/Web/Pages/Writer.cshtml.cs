using System.Security.Claims;
using Core.Constants;
using Shared.Interfaces.Repository;
using Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Interfaces.Services;

namespace Web.Pages
{
    public class WriterModel : PageModel
    {

        private readonly ICacheService _cacheService;
        private readonly ILogger<WriterModel> _logger;
        private readonly IPostService _postService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IExternalApiCalls _externalApiCalls;
        public bool IsTobiKareem { get; set; }
        public List<Post> BlogPosts { get; set; }
        private readonly IDataStore<Post> _blogPostRepo;
        public List<CustomCategory> Categories { get; set; }
        [BindProperty] public Post UserPost { get; set; }
        public int TotalBlogCount { get; set; }
        public string? ReturnUrl { get; set; }

        public WriterModel(IDataStore<Post> blogPostRepo, ICacheService cacheService, ILogger<WriterModel> logger, IPostService postService, UserManager<ApplicationUser> userManager, IExternalApiCalls externalApiCall)
        {
            _cacheService = cacheService;
            _blogPostRepo = blogPostRepo;
            _logger = logger;
            _postService = postService;
            _userManager = userManager;
            _externalApiCalls = externalApiCall;

            BlogPosts = new List<Post>();
            Categories = new List<CustomCategory>();
            UserPost = new Post { IsPublished = true, Category = new Category() };
        }

        public void OnGet()
        {
            IsTobiKareem = User.HasClaim(ClaimTypes.Role, ResourceAction.FortuneAdmin);
            BlogPosts = GetAllBlogPosts();

            ReturnUrl = Url.Page("/Writer");
            
            _logger.Log(LogLevel.Information, PageLogEventId.GeneralInformationCount, "Get all public blog posts count: {blogListCount}", BlogPosts.Count);

        }

        public void OnPostFilter(int id)
        {

            BlogPosts = GetAllBlogPosts();

            if (id == -1)
            {
                return;
            }

            BlogPosts = BlogPosts.Where(x => x.Category.Id == id).ToList();
            _logger.Log(LogLevel.Information, PageLogEventId.GeneralInformationCount, "Based on categoryID: {categoryId}, Get all public blog posts count: {blogListCount}", id, BlogPosts.Count);
        }

        public IActionResult? OnPostEditUserPost(int? id)
        {
            // check if user is logged in
            if (User.Identity is { IsAuthenticated: false })
            {
                return RedirectToPage("/Account/Login");
            }

            UserPost = _postService.GetPostById(id.GetValueOrDefault());

            return null;
        }


        public async Task<IActionResult> OnPostCreateNewAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            UserPost.UserId = user.Id;
            UserPost.CreatedBy = User.FindFirstValue(ClaimTypes.GivenName) ?? User.FindFirstValue("FirstName");
            UserPost.Enabled = true;

            _postService.CreateNewPost(UserPost, CacheEntry.Posts, true);

            await SendEmailToWriterAsync(user);
            
            return RedirectToPage("./Writer");

        }

        private List<Post> GetAllBlogPosts()
        {
            var blogList = _cacheService.GetOrCreate(CacheEntry.Posts, _blogPostRepo.GetAll, 180).ToList();
            var blog = blogList.Where(x => x.Category.Category1.ToLower() != "mindfeed").ToList();


            // populate the count of posts for each category
            foreach (var category in blog.Select(x => x.Category).Distinct())
            {
                Categories.Add(new CustomCategory
                {
                    Id = category.Id,
                    Category1 = category.Category1,
                    PostCount = blog.Count(x => x.Category.Id == category.Id)
                });
            }

            TotalBlogCount = blog.Count;
            return blog.OrderByDescending(x => x.Id).ThenBy(x => x.ModifiedOn).ToList();
        }


        private async Task SendEmailToWriterAsync(ApplicationUser user)
        {
            var email =
                $"<!Doctype html>\r\n<head>\r\n    <title>Thank You</title>\r\n\r\n</head>\r\n<body>\r\n\r\n    <div class=\"container bg-default\">\r\n\r\n        <h3 class=\"display-6\"> Hi {UserPost.CreatedBy},</h3>\r\n\r\n        <p class=\"lead\">Thank you for adding a post. I am very excited to read it :).</p>\r\n\r\n        <footer>\r\n            <p>Regards,</p>\r\n    <p>{EmailText.MyName}</p>\r\n          <p>Web: <a href=\"https://www.tobikareem.com\">Tobi Kareem</a></p>\r\n    <p>{EmailText.FortuneSign}</p>\r\n      </footer>\r\n\r\n        </div>\r\n\r\n\r\n</body>\r\n<footer></footer>\r\n\r\n</html>";

            await _externalApiCalls.SendGridEmail(user.Email, "Thank you for your post", "", UserPost.CreatedBy ?? string.Empty, email);

        }


        public class CustomCategory : Category
        {
            public int PostCount { get; set; }
        }
    }
}
