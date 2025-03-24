using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Database.Employee.Queries.GetEmployeeByEmail
{
    /// <summary>
    /// DI Constructor.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="mapper"></param>
    public class GetEmployeeByEmailQuery(IDataBaseService db, IMapper mapper) : IGetEmployeeByEmailQuery
    {
        private readonly IDataBaseService _db = db;
        private readonly IMapper _mapper = mapper;
        /// <summary>
        /// This method is used to get employee by email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<GetEmployeeByEmailModel?> Execute(string email)
        {
            return await (from employee in _db.Employees
                          join department in _db.Departments
                          on employee.DepartmentId equals department.Id
                          where employee.Email == email
                          select new GetEmployeeByEmailModel
                          {
                              Name = employee.Name,
                              DepartmentId = department.Id,
                              DepartmentName = department.Name,
                              Email = employee.Email,
                              Position = employee.Position,
                              Salary = employee.Salary
                          }).FirstOrDefaultAsync();
        }
    }
}
