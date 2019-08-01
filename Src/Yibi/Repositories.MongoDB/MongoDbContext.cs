using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Yibi.NoSqlCore.Entities;
using Yibi.NoSqlCore.Tables;

namespace Yibi.Repositories.MongoDB
{
    public class MongoDbContext: IMongoDbContext
    {
        private readonly IMongoDatabase _db;

        public MongoDbContext(IOptions<DatabaseOptions> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.InstanceName);
        }

        public IMongoCollection<Students> Students => _db.GetCollection<Students>("Students");
    }
}
