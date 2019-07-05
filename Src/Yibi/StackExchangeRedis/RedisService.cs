using System;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Yibi.StackExchangeRedis
{
    public class RedisService: IRedisService
    {
        private readonly IConnectionMultiplexer _connMultiplexer;
        private IDatabase Db { get; set; }

        public RedisService(IConnectionMultiplexer connMultiplexer)
        {
            _connMultiplexer = connMultiplexer;
            Db = _connMultiplexer.GetDatabase();
        }

        public async Task<string> GetValueAsync(string key)
        {
            return await Db.StringGetAsync(key);
        }

        public async Task RemoveAsync(string key)
        {
            await Db.KeyDeleteAsync(key);
        }

        public async Task<bool> SetValueAsync(string key, string value, TimeSpan? expiry = null)
        {
            return await Db.StringSetAsync(key, value, expiry, When.Always);
        }

        public async Task<bool> SetNxValueAsync(string key, string value, TimeSpan? expiry = null)
        {
            return await Db.StringSetAsync(key, value, expiry, When.NotExists);
        }
    }
}
