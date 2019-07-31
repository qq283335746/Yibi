using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Yibi.NoSqlCore.Configuration;
using Yibi.NoSqlCore.Entities;

namespace Yibi.NoSqlCore.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddYibiNoSqlCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureAndValidate<ConfigOptions>(configuration);
            services.ConfigureAndValidate<DatabaseOptions>(configuration.GetSection(nameof(ConfigOptions.NoSqlDatabase)));

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
