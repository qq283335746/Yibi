using System;
using System.Threading.Tasks;

namespace Yibi.StackExchangeRedis
{
    public interface IRedisService
    {
        Task<string> GetValueAsync(string key);

        Task RemoveAsync(string key);

        Task<bool> SetValueAsync(string key, string value, TimeSpan? expiry = null);

        Task<bool> SetNxValueAsync(string key, string value, TimeSpan? expiry = null);
    }
}
