using EmployeeManagement.Domain.Entities.Salary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Persistence.Configuration
{
    /// <summary>
    /// This method is used to Salary configuration builder.
    /// </summary>
    public class SalaryConfiguration
    {

        /// <summary>
        /// This method is sued to Salary configuration builder.
        /// </summary>
        /// <param name="builder"></param>
        public SalaryConfiguration(EntityTypeBuilder<SalaryEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Bonus).IsRequired().HasDefaultValue(0);

            // Initial Data
            builder.HasData(
                new SalaryEntity { Id = 1, Bonus = 0, Role = "HR_AND_SALES" }, // Fixed salary
                new SalaryEntity { Id = 2, Bonus = 10, Role = "DEVELOPERS" }, // 10% bonus
                new SalaryEntity { Id = 3, Bonus = 20, Role = "MANAGERS" } // 20% bonus
            );
        }
    }
}
