using EmployeeManagement.Domain.Entities.Department;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Persistence.Configuration
{
    /// <summary>
    /// This method is used to Department configuration builder.
    /// </summary>
    public class DepartmentConfiguration
    {
        /// <summary>
        /// This method is sued to Department configuration builder.
        /// </summary>
        /// <param name="builder"></param>
        public DepartmentConfiguration(EntityTypeBuilder<DepartmentEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ModificationDate).HasColumnType("DATETIME").HasDefaultValue(null);
            builder.Property(x => x.CreationDate).HasColumnType("DATETIME").IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
            #region Indexes
            builder.HasIndex(t => t.CreationDate).IsDescending();
            builder.HasIndex(t => t.Name);
            #endregion
            #region Foreign Key
            builder.HasMany(x => x.Employees).WithOne(x => x.Department).HasForeignKey(x => x.DepartmentId);
            #endregion
        }
    }
}
