using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yibi.Repositories.Core.Entities;

namespace Yibi.Repositories.Core.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseYibiEfCoreMigrate(this IApplicationBuilder app, IConfiguration configuration)
        {
            // Run migrations if necessary.
            var options = configuration.Get<ConfigOptions>();
            if (options.RunMigrationsAtStartup)
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    scope.ServiceProvider
                        .GetRequiredService<IContext>()
                        .Database
                        .Migrate();
                }
            }

            app.UsePathBase(options.PathBase);

            return app;
        }
    }
}
