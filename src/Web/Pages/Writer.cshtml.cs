using System.Security.Claims;
using Core.Constants;
using Shared.Interfaces.Repository;
using Data.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Interfaces.Services;

namespace Web.Pages
{
    public class WriterModel : PageModel
    {

        private readonly ICacheService _cacheService;
        private readonly ILogger<WriterModel> _logger;
        public bool IsTobiKareem { get; set; }
        public List<Post> BlogPosts { get; set; }
        private readonly IDataStore<Post> _blogPostRepo;
        public List<CustomCategory> Categories { get; set; }
        public int TotalBlogCount { get; set; }

        public WriterModel(IDataStore<Post> blogPostRepo, ICacheService cacheService, ILogger<WriterModel> logger)
        {
            _cacheService = cacheService;
            _blogPostRepo = blogPostRepo;
            _logger = logger;

            BlogPosts = new List<Post>();
            Categories = new List<CustomCategory>();
        }

        public void OnGet()
        {
            IsTobiKareem = User.HasClaim(ClaimTypes.Role, ResourceAction.FortuneAdmin);
            BlogPosts = GetAllBlogPosts();

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

        private List<Post> GetAllBlogPosts()
        {
            var blogList = _cacheService.GetOrCreate(CacheEntry.GetAllPosts, _blogPostRepo.GetAll, 180).ToList();
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
            return blog.OrderByDescending(x => x.ModifiedOn).ThenBy(x => x.Id).ToList();
        }

        public class CustomCategory : Category
        {
            public int PostCount { get; set; }
        }
    }
}
