using EmployeeManagement.Domain.Entities.Department;
using EmployeeManagement.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities.Employee
{
    public class EmployeeEntity
    {
        [Key]
        public int Id { get; set; }
        #region Foreign Key
        public required int DepartmentId { get; set; }
        public required DepartmentEntity Department { get; set; }
        #endregion
        public required string Name { get; set; }
        public required string Email { get; set; }
        public decimal Salary { get; set; }
        public JobPosition Position { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
