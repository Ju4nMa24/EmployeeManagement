namespace EmployeeManagement.Application.Database.Employee.Commands.CreateEmployee
{
    public interface ICreateEmployeeCommand
    {
        /// <summary>
        /// This method is used to create employee.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<CreateEmployeeModel?> Execute(CreateEmployeeModel model);
    }
}
