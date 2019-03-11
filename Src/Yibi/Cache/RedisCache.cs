using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yibi.Cache
{
    public class RedisCache:ICache
    {
        private readonly IDistributedCache _cache;

        public RedisCache(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<byte[]> GetAsync(string key)
        {
            return await _cache.GetAsync(key);
        }

        public async Task SetAsync(string key, string value)
        {
            await _cache.SetAsync(key, Encoding.Default.GetBytes(value));
        }
    }
}
