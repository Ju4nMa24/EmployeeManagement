using EmployeeManagement.Application.Database;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Entities.Department;
using EmployeeManagement.Domain.Entities.Employee;
using EmployeeManagement.Domain.Entities.Salary;
using EmployeeManagement.Persistence.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence.Database
{
    public class DataBaseService(DbContextOptions options) : IdentityDbContext<UserEntity>(options), IDataBaseService
    {
        #region DBSETs
        DbSet<UserEntity> IDataBaseService.Users { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<SalaryEntity> Salaries { get; set; }
        #endregion
        /// <summary>
        /// This method is used to save info.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }
        /// <summary>
        ///  Model Creating...   
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }
        /// <summary>
        /// Configuration models.
        /// </summary>
        /// <param name="modelBuilder"></param>
        private static void EntityConfiguration(ModelBuilder modelBuilder)
        {
            _ = new DepartmentConfiguration(modelBuilder.Entity<DepartmentEntity>());
            _ = new EmployeeConfiguration(modelBuilder.Entity<EmployeeEntity>());
            _ = new SalaryConfiguration(modelBuilder.Entity<SalaryEntity>());
        }

    }
}
