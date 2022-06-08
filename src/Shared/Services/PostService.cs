using Core.Constants;
using Data.Entity;
using Shared.Interfaces.Services;
using Shared.Interfaces.Repository;

namespace Shared.Services
{
    public class PostService : IPostService
    {
        private readonly IDataStore<Post> _postRepository;
        private readonly IDataStore<Category> _categoryRepository;
        private readonly ICacheService _cacheService;
        public PostService(IDataStore<Post> postRepository, IDataStore<Category> categoryRepository, ICacheService cacheService)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _cacheService = cacheService;
        }

        public void CreateNewPost(Post post, CacheEntry cacheKey, bool hasCache = false)
        {
            var categories = _cacheService.GetOrCreate(CacheEntry.Categories, _categoryRepository.GetAll, 120).ToList();
            if (post.Category == null || post.CategoryId == 0)
            {
                post.Category = categories.FirstOrDefault(x => x.Category1 == "Other");
            }
            else
            {
                post.Category = categories.First(x => x.Id == post.CategoryId.GetValueOrDefault());
            }

            post.Title = string.IsNullOrWhiteSpace(post.Title) ? "Untitled" : post.Title.Trim();
            post.Description = string.IsNullOrWhiteSpace(post.Description) ? "No description" : post.Description;

            post.IsReviewPost = post.Category?.Category1 == "Review";
            post.CategoryId = post.Category?.Id;
            post.CreatedOn = DateTime.UtcNow;
            post.IsPublished = true;
            post.Enabled = true;

            post.PostCategories.Add(new PostCategory { CategoryId = post.Category.Id });
            post.UserPosts.Add(new UserPost { UserId = post.UserId ?? string.Empty });



            _postRepository.AddEntity(post, cacheKey, hasCache);
        }

        public void UpdatePost(Post post, CacheEntry cacheKey, bool hasCache = false)
        {

            //var categories = _cacheService.GetOrCreate(CacheEntry.Categories, _categoryRepository.GetAll, 120).ToList();
            //post.Category = categories.First(x => x.Id == post.CategoryId.GetValueOrDefault());
            _postRepository.UpdateEntity(post, cacheKey, hasCache);
        }

        public Post GetPostById(int postId)
        {
            var blogList = _cacheService.GetOrCreate(CacheEntry.Posts, _postRepository.GetAll, 180).ToList();
            var post = blogList.Find(x => x.Id == postId);
            return post ?? new Post();
        }
    }
}
