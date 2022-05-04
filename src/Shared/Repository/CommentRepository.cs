using Core.Constants;
using Shared.Interfaces.Repository;
using Data.Context;
using Data.Entity;
using Shared.Interfaces.Services;

namespace Shared.Repository
{
    public class CommentRepository : IDataStore<Comment>
    {
        private readonly FortuneDbContext _dbContext;
        private readonly ICacheService _cacheService;

        public CommentRepository(FortuneDbContext fortuneDbContext, ICacheService cacheService)
        {
            _dbContext = fortuneDbContext;
            _cacheService = cacheService;
        }

        public void AddEntity(Comment entity, CacheEntry cacheKey, bool hasCache = false)
        {
            _dbContext.Comments.Add (entity);
            _dbContext.SaveChanges();
            if (hasCache)
            {
                _cacheService.Remove(cacheKey);
            }
        }

        public void Delete(int id)
        {
            var comment = GetById(id);

            _dbContext.Comments.Remove((Comment) comment);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Comment> GetAll()
        {
            return _dbContext.Comments.ToList();
        }

        public Comment GetById(int id)
        {
            var comment = GetAll().FirstOrDefault(x => x.Id == id);

            return comment ?? new Comment();
        }

        public IEnumerable<Comment> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Comment entity, CacheEntry cacheKey, bool hasCache = false)
        {
            _dbContext.Update<Comment> (entity);
            _dbContext.SaveChanges();

            if (hasCache)
            {
                _cacheService.Remove(cacheKey);
            }
        }
    }
}
