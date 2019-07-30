using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Repositories.LiteDB
{
    public static class LiteDbExtentions
    {
        public static void AddLiteDb(this IServiceCollection services, string databasePath)
        {
            services.AddTransient<LiteDbContext, LiteDbContext>();
            //services.Configure<LiteDbConfig>(options => options.DatabasePath = databasePath);
        }
    }
}
