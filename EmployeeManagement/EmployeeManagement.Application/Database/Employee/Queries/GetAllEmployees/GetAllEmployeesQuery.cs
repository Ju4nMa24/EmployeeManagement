using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Database.Employee.Queries.GetAllEmployees
{
    /// <summary>
    /// DI Constructor.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="mapper"></param>
    public class GetAllEmployeesQuery(IDataBaseService db, IMapper mapper) : IGetAllEmployeesQuery
    {
        private readonly IDataBaseService _db = db;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// This method is used to get all employees.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GetAllEmployeesModel>> Execute()
        {
            return await (from employee in _db.Employees
                          join department in _db.Departments
                          on employee.DepartmentId equals department.Id
                          select new GetAllEmployeesModel
                          {
                              Name = employee.Name,
                              DepartmentId = department.Id,
                              DepartmentName = department.Name,
                              Email = employee.Email,
                              Position = employee.Position,
                              Salary = employee.Salary
                          }).ToListAsync();
            
        }
    }
}
