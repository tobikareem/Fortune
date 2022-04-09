using Data.Entity;

namespace Shared.Interfaces.Services
{
    public interface IPostService
    {
        void CreateNewPost(Post post);

        void UpdatePost(Post post);
        Post GetPostById(int postId);
    }
}
