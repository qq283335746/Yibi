using System;
using System.Threading.Tasks;
using Yibi.Core.Entities;

namespace Yibi.Core.Services
{
    public interface IPackageService
    {
        Task<int> AddAsync(PackageInfo package);
    }
}
