using Microsoft.Extensions.Configuration;
using Yibi.Cache;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CacheServiceCollectionExtensions
    {
        public static IServiceCollection AddCacheService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "127.0.0.1:6379";
                options.InstanceName = "SampleInstance";
            });

            //services.AddDistributedRedisCache(options =>
            //{
            //    options.Configuration = "xx.xxx.xx.xxxx:6379,password=aaaaaa";
            //    options.InstanceName = "SampleInstance";
            //});

            services.AddScoped<ICache, RedisCache>();

            return services;
        }
    }
}
