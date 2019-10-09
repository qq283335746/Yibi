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

        //public DbSet<DepartmentInfo> Departments { get; set; }

        //public DbSet<StaffInfo> Staffs { get; set; }

        //public DbSet<Students> Students { get; set; }

        //public DbSet<Packages> Packages { get; set; }

        public Task<int> SaveChangesAsync() => SaveChangesAsync(default);

        public abstract bool IsUniqueConstraintViolationException(DbUpdateException exception);

        public virtual bool SupportsLimitInSubqueries => true;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ResourceGroupAccountInfo>(BuildResourceGroupAccountEntity);
            builder.Entity<TypeNameInfo>(BuildTypeNameEntity);
            builder.Entity<ContactInfo>(BuildContactEntity);
            builder.Entity<MessageTemplateInfo>(BuildMessageTemplateEntity);
            builder.Entity<ContactMessageNoticeInfo>(BuildContactMessageNoticeEntity);

            //builder.Entity<DepartmentInfo>(BuildDepartmentEntity);
            //builder.Entity<StaffInfo>(BuildStaffEntity);
            //builder.Entity<ProcessInstanceInfo>(BuildProcessInstanceEntity);

            //builder.Entity<Packages>(BuildPackageEntity);
            //builder.Entity<Students>(BuildStudentsEntity);
        }

        #region SGroupDb Server=10.168.95.225;Database=SGroupDb;Uid=yibi;Pwd=D640ms0GuuIZ46tOsU6o

        private void BuildResourceGroupAccountEntity(EntityTypeBuilder<ResourceGroupAccountInfo> entity)
        {
            entity.ToTable("ResourceGroupAccount");
            entity.HasKey(p => p.Id);
            entity.HasIndex(p => p.Id);
            entity.Property(p => p.Id)
               .IsRequired();
        }

        private void BuildTypeNameEntity(EntityTypeBuilder<TypeNameInfo> entity)
        {
            entity.ToTable("TypeNames");
            entity.HasKey(p => p.Id);
            entity.HasIndex(p => p.Id);
            entity.Property(p => p.Id)
               .IsRequired();
        }

        private void BuildContactEntity(EntityTypeBuilder<ContactInfo> entity)
        {
            entity.ToTable("Contacts");
            entity.HasKey(p => p.Id);
            entity.HasIndex(p => p.Id);
            entity.Property(p => p.Id)
               .IsRequired();
        }

        private void BuildMessageTemplateEntity(EntityTypeBuilder<MessageTemplateInfo> entity)
        {
            entity.ToTable("MessageTemplates");
            entity.HasKey(p => p.Id);
            entity.HasIndex(p => p.Id);
            entity.Property(p => p.Id)
               .IsRequired();
        }
        private void BuildContactMessageNoticeEntity(EntityTypeBuilder<ContactMessageNoticeInfo> entity)
        {
            entity.ToTable("ContactMessageNotices");
            entity.HasKey(p => p.Id);
            entity.HasIndex(p => p.Id);
            entity.HasIndex(p => p.ContactId);
            entity.Property(p => p.Id).IsRequired();
        }

        #endregion

        #region DingtalkDb Server=10.168.95.225;Database=DingtalkDb;Uid=yibi;Pwd=D640ms0GuuIZ46tOsU6o

        //private void BuildDepartmentEntity(EntityTypeBuilder<DepartmentInfo> entity)
        //{
        //    entity.ToTable("Department");
        //    entity.HasKey(p => p.Id);
        //    entity.HasIndex(p => p.Id);

        //    entity.Property(p => p.Id)
        //       .HasMaxLength(MaxNameLength)
        //       .IsRequired();

        //    entity.Property(p => p.Name).HasMaxLength(MaxNameLength);

        //}

        //private void BuildStaffEntity(EntityTypeBuilder<StaffInfo> entity)
        //{
        //    entity.ToTable("Staff");
        //    entity.HasKey(p => p.Id);
        //    entity.HasIndex(p => p.Id);

        //    entity.Property(p => p.Id)
        //       .HasMaxLength(MaxNameLength)
        //       .IsRequired();

        //    entity.Property(p => p.Name).HasMaxLength(MaxNameLength);

        //}

        //private void BuildProcessInstanceEntity(EntityTypeBuilder<ProcessInstanceInfo> entity)
        //{
        //    entity.ToTable("ProcessInstance");
        //    entity.HasKey(p => p.Id);
        //    entity.HasIndex(p => p.Id);

        //    entity.Property(p => p.Id)
        //       .HasMaxLength(MaxNameLength)
        //       .IsRequired();
        //}

        #endregion

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
