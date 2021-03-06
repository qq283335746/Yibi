﻿using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Yibi.Core.Configuration;
using Yibi.Core.Services;
using Yibi.Core.Entities;

namespace Yibi.Core.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddYibiCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureAndValidate<ConfigOptions>(configuration);
            services.ConfigureAndValidate<DatabaseOptions>(configuration.GetSection(nameof(ConfigOptions.Database)));

            services.AddScoped<IPackageService, PackageService>();

            services.AddScoped<IStudentService, StudentService>();

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
