using Data.Entity;
using Shared.Interfaces.Services;
using Shared.Interfaces.Repository;

namespace Shared.Services
{
    public class PostService : IPostService
    {
        private readonly IDataStore<Post> _postRepository;
        private readonly IDataStore<Category> _categoryRepository;
        public PostService(IDataStore<Post> postRepository, IDataStore<Category> categoryRepository)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
        }
        
        public void CreateNewPost(Post post)
        {
            post.CategoryId = _categoryRepository.GetAll().First(x => x.Category1 == post.Category.Category1).Id;
            post.IsReviewPost = false;
            post.Category = _categoryRepository.GetById(post.CategoryId.GetValueOrDefault());
            post.CreatedOn = DateTime.UtcNow;
            post.IsPublished = true;

            post.PostCategories.Add(new PostCategory { CategoryId = post.Category.Id });
            post.UserPosts.Add(new UserPost { UserId = post.UserId ?? string.Empty });



            _postRepository.AddEntity(post);
        }

        public void UpdatePost(Post post)
        {
            _postRepository.UpdateEntity(post);
        }

        public Post GetPostById(int postId)
        {
            var post = _postRepository.GetById(postId);
            return post;
        }
    }
}
