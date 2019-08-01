using System;
using Microsoft.Extensions.Options;
using LiteDB;
using Yibi.NoSqlCore.Entities;
using Yibi.NoSqlCore.Tables;

namespace Yibi.Repositories.LiteDB
{
    public class LiteDbContext: ILiteDbContext
    {
        public readonly LiteDatabase Context;

        public LiteDbContext(IOptionsSnapshot<DatabaseOptions> config)
        {
            var db = new LiteDatabase(config.Value.ConnectionString);
            if (db != null)
                Context = db;
        }

        public LiteCollection<Students> Students => Context.GetCollection<Students>("Students");
    }
}
