using System;
using System.Threading.Tasks;
using Yibi.Repositories.Core.Entities;

namespace Yibi.Repositories.Core.Services
{
    public interface IPackageService
    {
        Task<int> AddAsync(PackageInfo package);
    }
}
