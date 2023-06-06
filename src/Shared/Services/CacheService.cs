
using Core.Constants;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Shared.Interfaces.Services;

namespace Shared.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<CacheService> _logger;

        public CacheService(IMemoryCache cache, ILogger<CacheService> cacheLogger)
        {
            _cache = cache;
            _logger = cacheLogger;
        }

        public void Add<T>(CacheEntry key, T item, int duration)
        {
            _cache.Set(key, item, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(duration)
            });
        }

        public T GetItem<T>(CacheEntry key)
        {
            return _cache.Get<T>(key);
        }

        private T Get<T>(CacheEntry key)
        {
            return _cache.Get<T>(key);
        }

        public bool Contains(CacheEntry key)
        {
            return _cache.TryGetValue(key, out _);
        }

        public void Remove(CacheEntry key)
        {
            _cache.Remove(key);
        }

        public T GetOrCreate<T>(CacheEntry key, Func<T> createItem, int duration)
        {
            if (Contains(key))
            {
                return Get<T>(key);
            }
            
            _logger.Log(LogLevel.Information, PageLogEventId.CacheInformation, "{cacheKey} Item not in cache with {duration} duration", key, duration);
            var item = createItem();
            
            Add(key, item, duration);
            return item;
        }
    }
}
