using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Yibi.Core.Entities;
using Yibi.Core.Enums;
using Yibi.Repositories.MySql;
using Yibi.Repositories.Sqlite;
using Yibi.Repositories.PostgreSql;
using Yibi.Repositories.SqlServer;
using Yibi.Core.Extensions;
using Microsoft.Extensions.Configuration;
using Yibi.Core.Server.Extensions;
using Yibi.Repositories.LiteDB.Extensions;
using Yibi.NoSqlCore.Extensions;

namespace Yibi.Web.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddYibiConfigure(this IServiceCollection services, IConfiguration configuration, bool httpServices = false)
        {
            services.AddYibiCore(configuration);
            services.AddYibiNoSqlCore(configuration);

            services.AddLiteDb(configuration);

            if (httpServices)
            {
                services.ConfigureHttpServices();
            }

            return services;
        }

        public static IServiceCollection AddEfDbContext(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IContext>(provider =>
            {
                var databaseOptions = provider.GetRequiredService<IOptionsSnapshot<DatabaseOptions>>();

                switch (databaseOptions.Value.Type)
                {
                    case DatabaseType.Sqlite:
                        return provider.GetRequiredService<SqliteContext>();

                    case DatabaseType.MySql:
                        return provider.GetRequiredService<MySqlContext>();

                    case DatabaseType.PostgreSql:
                        return provider.GetRequiredService<PostgreSqlContext>();

                    case DatabaseType.SqlServer:
                        return provider.GetRequiredService<SqlServerContext>();

                    default:
                        throw new InvalidOperationException(
                            $"Unsupported database provider: {databaseOptions.Value.Type}");
                }
            });

            services.AddDbContext<SqliteContext>((provider, options) =>
            {
                var databaseOptions = provider.GetRequiredService<IOptionsSnapshot<DatabaseOptions>>();

                options.UseSqlite(databaseOptions.Value.ConnectionString);
            });

            services.AddDbContext<MySqlContext>((provider, options) =>
            {
                var databaseOptions = provider.GetRequiredService<IOptionsSnapshot<DatabaseOptions>>();

                options.UseMySql(databaseOptions.Value.ConnectionString);
            });

            services.AddDbContext<PostgreSqlContext>((provider, options) =>
            {
                var databaseOptions = provider.GetRequiredService<IOptionsSnapshot<DatabaseOptions>>();

                options.UseNpgsql(databaseOptions.Value.ConnectionString);
            });

            services.AddDbContext<SqlServerContext>((provider, options) =>
            {
                var databaseOptions = provider.GetRequiredService<IOptionsSnapshot<DatabaseOptions>>();

                options.UseSqlServer(databaseOptions.Value.ConnectionString);
            });

            return services;
        }
    }
}
