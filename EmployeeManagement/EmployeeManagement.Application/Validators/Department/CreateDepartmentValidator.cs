using EmployeeManagement.Application.Database.Department.Commands.CreateDepartment;
using FluentValidation;

namespace EmployeeManagement.Application.Validators.Department
{
    public class CreateDepartmentValidator : AbstractValidator<CreateDepartmentModel>
    {
        public CreateDepartmentValidator()
        {
            RuleFor(s => s.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(50);
        }
    }
}
