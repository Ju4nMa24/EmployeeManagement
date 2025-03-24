using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Entities.Department;
using EmployeeManagement.Domain.Entities.Employee;
using EmployeeManagement.Domain.Entities.Salary;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Database
{
    public interface IDataBaseService
    {
        #region DBSETs
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<SalaryEntity> Salaries { get; set; }
        #endregion
        /// <summary>
        /// This method is used to save info.
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveAsync();
    }
}
