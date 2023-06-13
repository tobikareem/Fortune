using Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces.Services
{
    public interface ICacheService
    {
        void Add<T>(CacheEntry key, T item, int duration);
        T GetItem<T>(CacheEntry key);

        bool Contains(CacheEntry key);
        void Remove(CacheEntry key);
        T GetOrCreate<T>(CacheEntry key, Func<T> createItem, int duration);
    }
}
