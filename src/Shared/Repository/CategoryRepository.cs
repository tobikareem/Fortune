using Core.Constants;
using Shared.Interfaces.Repository;
using Data.Entity;
using Data.Context;
using Shared.Interfaces.Services;

namespace Shared.Repository
{
    public class CategoryRepository : IDataStore<Category>
    {
        private readonly ICacheService _cacheService;
        private readonly FortuneDbContext _dbContext;
        public CategoryRepository(FortuneDbContext fortuneDbContext, ICacheService cacheService)
        {
            _dbContext = fortuneDbContext;
            _cacheService = cacheService;
        }

        public void AddEntity(Category entity, CacheEntry cacheKey, bool hasCache = false)
        {
            _dbContext.Categories.Add(entity);
            _dbContext.SaveChanges();

            if (hasCache)
            {
                _cacheService.Remove(cacheKey);
            }
        }

        public void Delete(int id)
        {
            var category = GetById(id);

            _dbContext.Categories.Remove((Category)category);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetById(int id)
        {
            var category = GetAll().FirstOrDefault(x => x.Id == id);

            return category ?? new Category();
        }

        public IEnumerable<Category> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Category entity, CacheEntry cacheKey, bool hasCache = false)
        {
            _dbContext.Update<Category>(entity);
            _dbContext.SaveChanges();

            if (hasCache)
            {
                _cacheService.Remove(cacheKey);
            }            
        }
    }
}
