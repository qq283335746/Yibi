using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Threading;
using System.Threading.Tasks;

namespace Yibi.Core.Entities
{
    public abstract class AbstractContext<TContext> : DbContext, IContext where TContext : DbContext
    {
        public const int DefaultMaxStringLength = 4000;
        public const int MaxNameLength = 256;

        public AbstractContext(DbContextOptions<TContext> options)
            : base(options)
        { }

        public DbSet<PackageInfo> Packages { get; set; }

        public Task<int> SaveChangesAsync() => SaveChangesAsync(default);

        public abstract bool IsUniqueConstraintViolationException(DbUpdateException exception);

        public virtual bool SupportsLimitInSubqueries => true;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PackageInfo>(BuildPackageEntity);
        }

        private void BuildPackageEntity(EntityTypeBuilder<PackageInfo> package)
        {
            package.HasKey(p => p.Key);
            package.HasIndex(p => p.Id);

            package.Property(p => p.Id)
               .HasMaxLength(MaxNameLength)
               .IsRequired();

            package.Property(p => p.Name).HasMaxLength(MaxNameLength);
            
        }
    }
}
