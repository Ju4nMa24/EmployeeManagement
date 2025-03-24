using System.Text.Json.Serialization;

namespace EmployeeManagement.Application.Database.Department.Commands.CreateDepartment
{
    public class CreateDepartmentModel
    {
        public required string Name { get; set; }
        [JsonIgnore]
        public DateTime CreationDate { get; set; }
        [JsonIgnore]
        public DateTime ModificationDate { get; set; }
    }
}
