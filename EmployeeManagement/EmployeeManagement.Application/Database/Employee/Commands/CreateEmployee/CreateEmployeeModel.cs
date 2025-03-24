using EmployeeManagement.Domain.Enums;
using System.Text.Json.Serialization;

namespace EmployeeManagement.Application.Database.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeModel
    {
        public required int DepartmentId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public decimal? Salary { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public JobPosition Position { get; set; }
        [JsonIgnore]
        public DateTime CreationDate { get; set; }
        [JsonIgnore]
        public DateTime ModificationDate { get; set; }
    }
}
