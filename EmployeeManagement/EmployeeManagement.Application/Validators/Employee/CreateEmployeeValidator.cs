using EmployeeManagement.Application.Database.Employee.Commands.CreateEmployee;
using EmployeeManagement.Common.Utilities;
using FluentValidation;

namespace EmployeeManagement.Application.Validators.Employee
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeModel>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(s => s.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(50);
            RuleFor(s => s.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(s => s.Position).NotEmpty().NotNull();
            RuleFor(s => s.Salary.ToString()).NotEmpty().NotNull().Must(Validations.IsDecimal);
            RuleFor(s => s.DepartmentId).NotEmpty().NotNull();

        }
    }
}
