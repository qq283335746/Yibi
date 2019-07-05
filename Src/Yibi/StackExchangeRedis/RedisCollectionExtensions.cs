using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.StackExchangeRedis
{
    public static class RedisCollectionExtensions
    {
        public static IServiceCollection AddRedisService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("10.168.95.121:6379,password=a135246A,abortConnect=false"));
            //services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(configuration["redis:entrypoint"]));

            services.AddSingleton<IRedisService, RedisService>();


            return services;
        }
    }
}
