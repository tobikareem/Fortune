using Shared.Interfaces.Repository;
using Data.Entity;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Shared.Repository
{
    public class PostRepository : IDataStore<Post>
    {
        private readonly FortuneDbContext _dbContext;
        public PostRepository(FortuneDbContext fortuneDbContext)
        {
            _dbContext = fortuneDbContext;
        }
        public void AddEntity(Post entity)
        {
            _dbContext.Posts.Add(entity);

            _dbContext.PostCategories.AddRange(entity.PostCategories);
            _dbContext.UserPosts.AddRange(entity.UserPosts);

            _dbContext.SaveChanges();

        }

        public void Delete(int id)
        {
            var posts = GetById(id);

            _dbContext.Posts.Remove((Post)posts);

            _dbContext.SaveChanges();

        }

        public void Delete(Post entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {

            return Enumerable.Empty<Post>();
        }

        public Post GetById(int id)
        {
            var post = GetAll().FirstOrDefault(x => x.Id == id);

            return post ?? new Post();
        }

        public Post GetById(Post entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Post entity)
        {
            _dbContext.Update<Post>(entity);
            _dbContext.SaveChanges();
        }
    }
}
