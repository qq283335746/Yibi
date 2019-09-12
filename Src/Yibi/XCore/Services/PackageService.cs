using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yibi.Core.Entities;

namespace Yibi.Core.Services
{
    public class PackageService : IPackageService
    {
        private readonly IContext _context;

        public PackageService(IContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> AddAsync(Packages package)
        {
            try
            {
                //_context.Packages.Add(package);

                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e) when (_context.IsUniqueConstraintViolationException(e))
            {
                return 2;
            }
        }
    }
}
