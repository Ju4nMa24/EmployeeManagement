using AutoMapper;
using EmployeeManagement.Domain.Entities.Employee;

namespace EmployeeManagement.Application.Database.Employee.Commands.DeleteEmployee
{
    /// <summary>
    /// DI Constructor.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="mapper"></param>
    public class DeleteEmployeeCommand(IDataBaseService db, IMapper mapper) : IDeleteEmployeeCommand
    {
        private readonly IDataBaseService _db = db;
        private readonly IMapper _mapper = mapper;
        /// <summary>
        /// This method is used to delete employee.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<bool> Execute(string email)
        {
            EmployeeEntity? employee = _db.Employees.FirstOrDefault(e => e.Email == email);
            if (employee == null || string.IsNullOrEmpty(email))
                return false;

            _db.Employees.Remove(employee);
            return await _db.SaveAsync();
        }
    }
}
