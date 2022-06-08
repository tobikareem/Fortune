using Core.Constants;
using Shared.Interfaces.Repository;
using Data.Entity;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces.Services;

namespace Shared.Repository
{
    public class PostRepository : IDataStore<Post>
    {
        private readonly FortuneDbContext _dbContext;
        private readonly ICacheService _cacheService;
        public PostRepository(FortuneDbContext fortuneDbContext, ICacheService cacheService)
        {
            _dbContext = fortuneDbContext;
            _cacheService = cacheService;
        }
        
        public void AddEntity(Post entity, CacheEntry cacheKey, bool hasCache = false)
        {
            _dbContext.Attach(entity).State = EntityState.Added;

            _dbContext.Posts.Add(entity);
            _dbContext.PostCategories.AddRange(entity.PostCategories);
            _dbContext.UserPosts.AddRange(entity.UserPosts);
            _dbContext.SaveChanges();

            if (hasCache)
            {
                _cacheService.Remove(cacheKey);
            }
        }

        public void Delete(int id)
        {
            var posts = GetById(id);

            _dbContext.Posts.Remove(posts);

            _dbContext.SaveChanges();

        }

        public IEnumerable<Post> GetAll()
        {
            return _dbContext.Posts.Where(x => x.Enabled).Include(x => x.Category).ToList();

        }

        public Post GetById(int id)
        {
            var post = _dbContext.Posts.Where(x => x.Enabled).FirstOrDefault(x => x.Id == id);

            return post ?? new Post();
        }


        public IEnumerable<Post> GetByUserId(string userId)
        {
            return _dbContext.Posts.Include(x => x.Category).Include(x => x.User)
                .Where(x => x.User != null && x.User.Id == userId).ToList();
        }

        public void UpdateEntity(Post entity, CacheEntry cacheKey, bool hasCache = false)
        {
            _dbContext.Attach(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();

            if (hasCache)
            {
                _cacheService.Remove(cacheKey);
            }


            //_dbContext.Posts.FromSqlRaw("UPDATE Posts SET" +
            //                            " Title = {0}," +
            //                            " Content = {1}, " +
            //                            " Description = {2}, " +
            //                            " Enabled = {3}, " +
            //                            " IsPublished = {4}, " +
            //                            "CategoryId = {5} " +
            //                            "WHERE Id = {6}", 
            //    entity.Title, entity.Content, entity.Description, entity.Enabled, entity.IsPublished, entity.Category.Id, entity.Id);
        }
    }
}
