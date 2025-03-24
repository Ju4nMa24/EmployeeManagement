using EmployeeManagement.Application.Database.Department.Commands.UpdateDepartment;
using FluentValidation;

namespace EmployeeManagement.Application.Validators.Department
{
    public class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentModel>
    {
        public UpdateDepartmentValidator()
        {
            RuleFor(s => s.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(50);
        }
    }
}
