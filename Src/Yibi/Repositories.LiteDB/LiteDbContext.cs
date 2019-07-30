using LiteDB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Yibi.Core.Entities;

namespace Yibi.Repositories.LiteDB
{
    public class LiteDbContext
    {
        public readonly LiteDatabase Context;
        public LiteDbContext(IOptionsSnapshot<DatabaseOptions> configs)
        {
            try
            {
                var db = new LiteDatabase(configs.Value.ConnectionString);
                if (db != null)
                    Context = db;
            }
            catch (Exception ex)
            {
                throw new Exception("Can find or create LiteDb database.", ex);
            }
        }
    }
}
