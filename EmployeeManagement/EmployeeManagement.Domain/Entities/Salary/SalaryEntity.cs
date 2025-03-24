using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities.Salary
{
    public class SalaryEntity
    {
        [Key]
        public int Id { get; set; }
        public required string Role { get; set; }
        public decimal Bonus { get; set; }
    }
}
