using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using Yibi.NoSqlCore.Tables;

namespace Yibi.Repositories.LiteDB
{
    public interface ILiteDbContext
    {
        LiteCollection<Students> Students { get; }
    }
}
