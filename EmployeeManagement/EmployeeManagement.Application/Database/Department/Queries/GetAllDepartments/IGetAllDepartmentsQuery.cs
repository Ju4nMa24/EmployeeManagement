namespace EmployeeManagement.Application.Database.Department.Queries.GetAllDepartments
{
    public interface IGetAllDepartmentsQuery
    {
        /// <summary>
        /// This method is used to get all departments.
        /// </summary>
        /// <returns></returns>
        Task<List<GetAllDepartmentsModel>> Execute();
    }
}
