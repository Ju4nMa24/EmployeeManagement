namespace EmployeeManagement.Application.Database.Employee.Commands.DeleteEmployee
{
    public interface IDeleteEmployeeCommand
    {
        /// <summary>
        /// This method is used to delete employee.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<bool> Execute(string email);
    }
}
