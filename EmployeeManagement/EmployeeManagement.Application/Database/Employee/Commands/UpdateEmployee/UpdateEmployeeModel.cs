using EmployeeManagement.Domain.Enums;
using System.Text.Json.Serialization;

namespace EmployeeManagement.Application.Database.Employee.Commands.UpdateEmployee
{
    public class UpdateEmployeeModel
    {
        public required int DepartmentId { get; set; }
        public required string Name { get; set; }
        public required string OldEmail { get; set; }
        public string? NewEmail { get; set; }
        public decimal Salary { get; set; }
        public JobPosition Position { get; set; }
        [JsonIgnore]
        public DateTime ModificationDate { get; set; }
    }
}
