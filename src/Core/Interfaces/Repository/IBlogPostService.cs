using Core.Models;

namespace Core.Interfaces.Repository
{
    public interface IBlogPostService
    {
        IEnumerable<BlogPost> GetAllBlogPosts();
    }
}
