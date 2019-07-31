using System;
using Microsoft.Extensions.Options;
using LiteDB;
using Yibi.NoSqlCore.Entities;

namespace Yibi.Repositories.LiteDB
{
    public class LiteDbContext
    {
        public readonly LiteDatabase Context;
        public LiteDbContext(IOptionsSnapshot<DatabaseOptions> config)
        {
            var db = new LiteDatabase(config.Value.ConnectionString);
            if (db != null)
                Context = db;
        }
    }
}
