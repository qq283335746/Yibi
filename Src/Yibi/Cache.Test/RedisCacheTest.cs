using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yibi.Cache.Test
{
    public class RedisCacheTest
    {
        private readonly ICache _cache;

        public RedisCacheTest(ICache cache)
        {
            _cache = cache;
        }

        public async Task Get()
        {
            await _cache.GetAsync("mykey");
        }
    }
}
