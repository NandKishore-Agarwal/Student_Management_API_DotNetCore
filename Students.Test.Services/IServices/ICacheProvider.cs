using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Test.Services.IServices
{
    /// <summary>
    /// ICacheProvider.
    /// </summary>
    public interface ICacheProvider
    {
        /// <summary>
        /// Set Cache.
        /// </summary>
        /// <param name="cacheName">CacheName.</param>
        /// <param name="value">value.</param>
        void SetCache(string cacheName, object value);

        /// <summary>
        /// Check if cache exists.
        /// </summary>
        /// <param name="cacheName">CacheName.</param>
        /// <param name="value">value.</param>
        /// <param name="isExist">isExist.</param>
        void IsCacheExists<T>(string cacheName, out T value, out bool isExist);

        /// <summary>
        /// Get Cache<typeparamref name="T"/>.
        /// </summary>
        /// <param name="cacheName">CacheName.</param>
        T GetCache<T>(string cacheName);
    }
}
