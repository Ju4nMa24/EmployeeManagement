using EmployeeManagement.Domain.Entities.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Persistence.Configuration
{
    /// <summary>
    /// This method is used to Employee configuration builder.
    /// </summary>
    public class EmployeeConfiguration
    {
        /// <summary>
        /// This method is sued to Employee configuration builder.
        /// </summary>
        /// <param name="builder"></param>
        public EmployeeConfiguration(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(e => e.Salary).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ModificationDate).HasColumnType("DATETIME").HasDefaultValue(null);
            builder.Property(x => x.CreationDate).HasColumnType("DATETIME").IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
            #region Indexes
            builder.HasIndex(t => t.CreationDate).IsDescending();
            builder.HasIndex(t => t.Name);
            #endregion
        }
    }
}
