using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Yibi.Repositories.Core.Entities;
using Yibi.Repositories.Core.Enums;
using Yibi.Repositories.MySql;
using Yibi.Repositories.Sqlite;
using Yibi.Repositories.PostgreSql;
using Yibi.Repositories.SqlServer;

namespace Yibi.Web.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddMultiDbContext(this IServiceCollection services)
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
