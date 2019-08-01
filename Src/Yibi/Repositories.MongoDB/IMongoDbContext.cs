using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Yibi.NoSqlCore.Tables;

namespace Yibi.Repositories.MongoDB
{
    public interface IMongoDbContext
    {
        IMongoCollection<Students> Students { get; }
    }
}
