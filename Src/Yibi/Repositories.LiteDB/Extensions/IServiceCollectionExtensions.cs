using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Yibi.NoSqlCore.Entities;
using Yibi.NoSqlCore.Enums;
using Yibi.NoSqlCore.Services;
using Yibi.Repositories.LiteDB.Services;

namespace Yibi.Repositories.LiteDB.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddLiteDb(this IServiceCollection services, IConfiguration configuration)
        {
            var noSqlDatabaseConfig = configuration.GetSection("NoSqlDatabase").Get<DatabaseOptions>();
            //var wrappedDescriptors = services.Where(s => s.ServiceType == typeof(IStudentService)).ToList();

            if(noSqlDatabaseConfig.Type == DatabaseType.LiteDb)
            {
                services.AddTransient<ILiteDbContext, LiteDbContext>();
                //services.Configure<LiteDbConfig>(options => options.DatabasePath = configuration.GetSection("Database:ConnectionString").Value);

                services.AddScoped<IStudentService, StudentService>();
            }
        }
    }
}
