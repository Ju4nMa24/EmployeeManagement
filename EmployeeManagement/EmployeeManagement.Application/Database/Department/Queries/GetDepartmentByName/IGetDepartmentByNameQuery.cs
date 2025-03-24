namespace EmployeeManagement.Application.Database.Department.Queries.GetDepartmentByName
{
    public interface IGetDepartmentByNameQuery
    {
        /// <summary>
        /// This method is used to get department by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<GetDepartmentByNameModel?> Execute(string name);
    }
}
