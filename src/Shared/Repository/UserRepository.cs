using Core.Constants;
using Data.Context;
using Shared.Interfaces.Repository;
using Microsoft.AspNetCore.Identity;
using Shared.Interfaces.Services;

namespace Shared.Repository
{
    public class UserRepository: IStringIdStore<IdentityUser>
    {
        private readonly FortuneDbContext _dbContext;
        private readonly ICacheService _cacheService;
        public UserRepository(FortuneDbContext fortuneDbContext, ICacheService cacheService)
        {
            _dbContext = fortuneDbContext;
            _cacheService = cacheService;
        }

        public void AddEntity(IdentityUser entity, CacheEntry cacheKey, bool hasCache = false)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();

            if (hasCache)
            {
                _cacheService.Remove(cacheKey);
            }            
        }

        public void Delete(string id)
        {
            var user = GetById(id);

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public IEnumerable<IdentityUser> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public IdentityUser GetById(string id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            return user ?? new IdentityUser();
        }

        public void UpdateEntity(IdentityUser entity, CacheEntry cacheKey, bool hasCache = false)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();

            if (hasCache)
            {
                _cacheService.Remove(cacheKey);
            }
        }
    }
}
