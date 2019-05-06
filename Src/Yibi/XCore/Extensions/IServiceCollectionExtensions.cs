using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Yibi.Core.Configuration;
using Yibi.Core.Services;
using Yibi.Core.Entities;
using Yibi.Core.Enums;

namespace Yibi.Core.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureAndValidate<TOptions>(this IServiceCollection services, IConfiguration config) where TOptions : class
        {
            services.Configure<TOptions>(config);
            services.AddSingleton<IPostConfigureOptions<TOptions>, ValidatePostConfigureOptions<TOptions>>();

            return services;
        }
    }
}
