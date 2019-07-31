using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yibi.NoSqlCore.Services;
using Yibi.Repositories.LiteDB.Services;

namespace Yibi.Repositories.LiteDB.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddLiteDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<LiteDbContext, LiteDbContext>();
            //services.Configure<LiteDbConfig>(options => options.DatabasePath = configuration.GetSection("Database:ConnectionString").Value);

            services.AddScoped<IStudentService, StudentService>();
        }
    }
}
