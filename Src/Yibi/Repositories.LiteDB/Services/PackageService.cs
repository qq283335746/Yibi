using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yibi.Core.Entities;
using Yibi.Core.Services;

namespace Yibi.Repositories.LiteDB.Services
{
    public class PackageService : IPackageService
    {
        private readonly LiteDbContext _db;

        public PackageService(LiteDbContext db)
        {
            _db = db;
        }

        public async Task<int> AddAsync(PackageInfo package)
        {
            var result = await Task.Run(() =>
            {
                var packages = _db.Context.GetCollection<PackageInfo>();
                packages.Insert(package);

                return 1;
            });

            return result;
        }
    }
}
