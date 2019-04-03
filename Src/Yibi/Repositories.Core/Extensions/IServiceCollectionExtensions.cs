using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Yibi.Repositories.Core.Configuration;
using Yibi.Repositories.Core.Services;
using Yibi.Repositories.Core.Entities;
using Yibi.Repositories.Core.Enums;

namespace Yibi.Repositories.Core.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddYibiRepositories(this IServiceCollection services,IConfiguration configuration,bool httpServices = false)
        {
            services.ConfigureAndValidate<ConfigOptions>(configuration);
            services.ConfigureAndValidate<DatabaseOptions>(configuration.GetSection(nameof(ConfigOptions.Database)));

            services.AddScoped<IPackageService, PackageService>();

            return services;
        }

        public static IServiceCollection ConfigureAndValidate<TOptions>(this IServiceCollection services, IConfiguration config) where TOptions : class
        {
            services.Configure<TOptions>(config);
            services.AddSingleton<IPostConfigureOptions<TOptions>, ValidatePostConfigureOptions<TOptions>>();

            return services;
        }
    }
}
