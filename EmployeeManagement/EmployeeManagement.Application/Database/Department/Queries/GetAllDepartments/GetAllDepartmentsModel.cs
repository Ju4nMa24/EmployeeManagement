using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Application.Database.Department.Queries.GetAllDepartments
{
    public class GetAllDepartmentsModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }
}
