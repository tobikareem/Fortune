using Core.Constants;
using Data.Entity;

namespace Shared.Interfaces.Services
{
    public interface IPostService
    {
        void CreateNewPost(Post post, CacheEntry cacheKey, bool hasCache = false);

        void UpdatePost(Post post, CacheEntry cacheKey, bool hasCache = false);
        Post GetPostById(int postId);
    }
}
