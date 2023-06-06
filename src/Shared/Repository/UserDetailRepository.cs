using Core.Constants;
using Data.Context;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces.Repository;
using Shared.Interfaces.Services;

namespace Shared.Repository;

public class UserDetailRepository: IDataStore<UserDetail>
{
    private readonly FortuneDbContext _context;
    private readonly ICacheService _cacheService;
    public UserDetailRepository(FortuneDbContext context, ICacheService cacheService)
    {
        _context = context;
        _cacheService = cacheService;
    }
    public void AddEntity(UserDetail entity, CacheEntry cacheKey, bool hasCache = false)
    {
        _context.UserDetails.Add(entity);
        _context.SaveChanges();

        if (hasCache)
        {
            _cacheService.Remove(cacheKey);
        }
    }

    public void UpdateEntity(UserDetail entity, CacheEntry cacheKey, bool hasCache = false)
    {
        _context.Attach(entity).State = EntityState.Modified;
        _context.SaveChanges();

        if (hasCache)
        {
            _cacheService.Remove(cacheKey);
        }
    }

    public IEnumerable<UserDetail> GetAll()
    {
        return _context.UserDetails.Include(x => x.User).ToList();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public UserDetail GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<UserDetail> GetByUserId(string userId)
    {
        var userById = GetAll().Where(x => x.UserId == userId);

        return userById;
    }
}