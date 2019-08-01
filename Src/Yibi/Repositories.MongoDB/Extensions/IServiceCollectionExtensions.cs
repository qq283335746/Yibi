using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yibi.NoSqlCore.Services;
using Yibi.Repositories.MongoDB.Services;

namespace Yibi.Repositories.MongoDB.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IMongoDbContext, MongoDbContext>();

            services.AddScoped<IStudentService, StudentService>();
        }
    }
}
