using EmployeeManagement.Domain.Entities.Employee;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities.Department
{
    public class DepartmentEntity
    {
        [Key]
        public required int Id { get; set; }
        public required string Name { get; set; }
        #region Foreign Key
        public ICollection<EmployeeEntity>? Employees { get; set; }
        #endregion
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
