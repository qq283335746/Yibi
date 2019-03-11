using Microsoft.Extensions.Configuration;
using Yibi.Eureka;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EurekaServiceCollectionExtensions
    {
        public static IServiceCollection AddEurekaService(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddHttpClient();

            services.AddSingleton<IEurekaService, EurekaService>();

            return services;
        }
    }
}
