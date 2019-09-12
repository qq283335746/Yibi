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

        public DbSet<StaffInfo> Staffs { get; set; }

        //public DbSet<Students> Students { get; set; }

        //public DbSet<Packages> Packages { get; set; }

        public Task<int> SaveChangesAsync() => SaveChangesAsync(default);

        public abstract bool IsUniqueConstraintViolationException(DbUpdateException exception);

        public virtual bool SupportsLimitInSubqueries => true;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StaffInfo>(BuildStaffEntity);
            //builder.Entity<Packages>(BuildPackageEntity);
            //builder.Entity<Students>(BuildStudentsEntity);
        }

        private void BuildStaffEntity(EntityTypeBuilder<StaffInfo> staff)
        {
            staff.ToTable("Staff");
            staff.HasKey(p => p.Id);
            staff.HasIndex(p => p.Id);

            staff.Property(p => p.Id)
               .HasMaxLength(MaxNameLength)
               .IsRequired();

            staff.Property(p => p.Name).HasMaxLength(MaxNameLength);

        }

        //private void BuildPackageEntity(EntityTypeBuilder<Packages> package)
        //{
        //    package.HasKey(p => p.Key);
        //    package.HasIndex(p => p.Id);

        //    package.Property(p => p.Id)
        //       .HasMaxLength(MaxNameLength)
        //       .IsRequired();

        //    package.Property(p => p.Name).HasMaxLength(MaxNameLength);
            
        //}

        //private void BuildStudentsEntity(EntityTypeBuilder<Students> package)
        //{
        //    package.HasKey(p => p.Id);
        //    package.HasIndex(p => p.Id);
        //}
    }
}
