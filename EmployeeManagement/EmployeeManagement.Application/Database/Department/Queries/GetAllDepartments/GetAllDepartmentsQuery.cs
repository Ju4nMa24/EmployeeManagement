
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Database.Department.Queries.GetAllDepartments
{
    /// <summary>
    /// DI Constructor.
    /// </summary>
    /// <param name="db"></param>
    public class GetAllDepartmentsQuery(IDataBaseService db) : IGetAllDepartmentsQuery
    {
        private readonly IDataBaseService _db = db;
        /// <summary>
        /// This method is used to get all departments.
        /// </summary>
        /// <returns></returns>
        public async Task<List<GetAllDepartmentsModel>> Execute()
        {
            return await _db.Departments
                .Select(department => new GetAllDepartmentsModel
                {
                    Id = department.Id,
                    Name = department.Name
                }).ToListAsync();
        }
    }
}
