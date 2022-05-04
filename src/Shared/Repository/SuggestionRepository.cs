using Core.Constants;
using Data.Context;
using Data.Entity;
using Shared.Interfaces.Repository;
using Shared.Interfaces.Services;

namespace Shared.Repository
{
    public class SuggestionRepository: IBaseStore<Suggestions>
    {
        private readonly FortuneDbContext _dbContext;
        private readonly ICacheService _cacheService;
        public SuggestionRepository(FortuneDbContext dbContext, ICacheService cacheService)
        {
            _dbContext = dbContext;
            _cacheService = cacheService;
        }
        
        public void AddEntity(Suggestions entity, CacheEntry cacheKey, bool hasCache = false)
        {
            _dbContext.Suggestions.Add(entity);
            _dbContext.SaveChanges();
            if (hasCache)
            {
                _cacheService.Remove(cacheKey);
            }
        }

        public void UpdateEntity(Suggestions entity, CacheEntry cacheKey, bool hasCache = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Suggestions> GetAll()
        {
            return _dbContext.Suggestions.ToList();
        }
    }
}
