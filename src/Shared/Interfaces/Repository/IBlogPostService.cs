using Core.Models;

namespace Shared.Interfaces.Repository
{
    public interface IBlogPostService
    {
        IEnumerable<BlogPost> GetAllBlogPosts();
    }
}
