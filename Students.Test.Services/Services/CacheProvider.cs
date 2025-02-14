using System;
using Microsoft.Extensions.Caching.Memory;
using Students.Test.Services.IServices;

namespace Students.Test.Services.Services
{
    /// <summary>
    /// CacheProvider class.
    /// </summary>
    public class CacheProvider : ICacheProvider
    {
        private readonly IMemoryCache _memoryCache;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CacheProvider"/> class..
        /// </summary>
        /// <param name="memoryCache">memoryCache.</param>
        public CacheProvider(IMemoryCache memoryCache)
        {
            this._memoryCache = memoryCache;
        }

        /// <inheritdoc />
        public void SetCache(string cacheName, object student)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                                .SetSlidingExpiration(TimeSpan.FromSeconds(30));

            this._memoryCache.Set(cacheName, student, cacheEntryOptions);
        }

        /// <inheritdoc />
        public void IsCacheExists<T>(string cacheName, out T value, out bool isExist)
        {
            isExist = this._memoryCache.TryGetValue(cacheName, out value);
        }

        /// <inheritdoc />
        public T GetCache<T>(string cacheName)
        {
            return this._memoryCache.Get<T>(cacheName);
        }
    }
}
