namespace EmployeeManagement.Application.Database.Employee.Queries.GetAllEmployees
{
    public interface IGetAllEmployeesQuery
    {
        /// <summary>
        /// This method is used to get all employees.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<GetAllEmployeesModel>> Execute();
    }
}
