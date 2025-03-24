using EmployeeManagement.Application.Database.Employee.Commands.UpdateEmployee;
using EmployeeManagement.Common.Utilities;
using FluentValidation;

namespace EmployeeManagement.Application.Validators.Employee
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeModel>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(s => s.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(50);
            RuleFor(s => s.OldEmail).NotEmpty().NotNull().EmailAddress();
            RuleFor(s => s.NewEmail).EmailAddress();
            RuleFor(s => s.Position).NotEmpty().NotNull();
            RuleFor(s => s.Salary.ToString()).NotEmpty().NotNull().Must(Validations.IsDecimal);
            RuleFor(s => s.DepartmentId).NotEmpty().NotNull();
        }
    }
}
