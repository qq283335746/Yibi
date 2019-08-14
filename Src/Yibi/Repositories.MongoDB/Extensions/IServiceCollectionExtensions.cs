using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Yibi.NoSqlCore.Entities;
using Yibi.NoSqlCore.Enums;
using Yibi.NoSqlCore.Services;
using Yibi.Repositories.MongoDB.Services;

namespace Yibi.Repositories.MongoDB.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            var noSqlDatabaseConfig = configuration.GetSection("NoSqlDatabase").Get<DatabaseOptions>();
            //var wrappedDescriptors = services.Where(s => s.ServiceType == typeof(IStudentService)).ToList();

            if(noSqlDatabaseConfig.Type == DatabaseType.MongoDb)
            {
                services.AddTransient<IMongoDbContext, MongoDbContext>();
                services.AddScoped<IStudentService, StudentService>();
            }
        }
    }
}
