using Core.Interfaces.Repository;
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

        public IEnumerable<Post> GetAll()
        {

            using var context = new FortuneDbContext();

            return _dbContext.Posts.Include(y => y.Category).Where(x => x.Enabled).ToList();
        }

        public Post GetById(int id)
        {
            var post = GetAll().FirstOrDefault(x => x.Id == id);

            return post ?? new Post();
        }

        public void UpdateEntity(Post entity)
        {
            _dbContext.Update<Post>(entity);
            _dbContext.SaveChanges();
        }
    }
}
