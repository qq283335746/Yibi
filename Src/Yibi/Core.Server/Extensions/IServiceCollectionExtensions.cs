using Yibi.Core.Server.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Yibi.Core.Server.Controllers;

namespace Yibi.Core.Server.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureHttpServices(this IServiceCollection services)
        {
            services
                .AddMvc()
                .AddApplicationPart(typeof(PackageController).Assembly)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors();
            services.AddSingleton<IConfigureOptions<CorsOptions>, ConfigureCorsOptions>();
            services.AddSingleton<IConfigureOptions<ForwardedHeadersOptions>, ConfigureForwardedHeadersOptions>();
            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = int.MaxValue;
            });

            return services;
        }
    }
}
