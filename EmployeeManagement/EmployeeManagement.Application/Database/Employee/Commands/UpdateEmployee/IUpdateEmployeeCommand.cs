using EmployeeManagement.Application.Database.Employee.Commands.CreateEmployee;

namespace EmployeeManagement.Application.Database.Employee.Commands.UpdateEmployee
{
    public interface IUpdateEmployeeCommand
    {
        /// <summary>
        /// This method is used to update employee.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Execute(UpdateEmployeeModel model);
    }
}
