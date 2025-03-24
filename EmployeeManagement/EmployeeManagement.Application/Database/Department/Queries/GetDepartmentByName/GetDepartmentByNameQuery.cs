
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Database.Department.Queries.GetDepartmentByName
{
    /// <summary>
    /// DI Constructor.
    /// </summary>
    /// <param name="db"></param>
    public class GetDepartmentByNameQuery(IDataBaseService db) : IGetDepartmentByNameQuery
    {
        private readonly IDataBaseService _db = db;
        /// <summary>
        /// This method is used to get department by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<GetDepartmentByNameModel?> Execute(string name)
        {
            return await(from department in _db.Departments
                         where department.Name == name
                         select new GetDepartmentByNameModel
                         {
                             Id = department.Id,
                             Name = department.Name
                         }).FirstOrDefaultAsync();
        }
    }
}
