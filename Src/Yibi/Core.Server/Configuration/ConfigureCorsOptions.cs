using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Options;

namespace Yibi.Core.Server.Configuration
{
    public class ConfigureCorsOptions : IConfigureOptions<CorsOptions>
    {
        public const string CorsPolicy = "AllowAll";

        public void Configure(CorsOptions options)
        {
            options.AddPolicy(
                CorsPolicy,
                builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        }
    }
}
