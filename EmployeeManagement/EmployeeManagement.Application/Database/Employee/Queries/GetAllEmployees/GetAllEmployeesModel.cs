using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Application.Database.Employee.Queries.GetAllEmployees
{
    public class GetAllEmployeesModel
    {
        public required int DepartmentId { get; set; }
        public required string DepartmentName { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public decimal Salary { get; set; }
        public JobPosition Position { get; set; }
    }
}
