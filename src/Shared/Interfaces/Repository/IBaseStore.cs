using Core.Constants;

namespace Shared.Interfaces.Repository
{
    public interface IBaseStore<T> where T : class
    {
        void AddEntity(T entity, CacheEntry cacheKey = CacheEntry.NoEntry, bool hasCache = false);
        void UpdateEntity(T entity, CacheEntry cacheKey = CacheEntry.NoEntry, bool hasCache = false);
        IEnumerable<T> GetAll();

    }
}
