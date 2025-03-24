namespace EmployeeManagement.Application.Database.Employee.Queries.GetEmployeeByEmail
{
    public interface IGetEmployeeByEmailQuery
    {
        /// <summary>
        /// This method is used to get employee by email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<GetEmployeeByEmailModel?> Execute(string email);
    }
}
