using AutoMapper;
using EmployeeManagement.Common.Constants;
using EmployeeManagement.Domain.Entities.Employee;
using EmployeeManagement.Domain.Enums;
using System.Configuration;

namespace EmployeeManagement.Application.Database.Employee.Commands.CreateEmployee
{
    /// <summary>
    /// DI Constructor.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="mapper"></param>
    public class CreateEmployeeCommand(IDataBaseService db, IMapper mapper) : ICreateEmployeeCommand
    {
        private readonly IDataBaseService _db = db;
        private readonly IMapper _mapper = mapper;
        /// <summary>
        /// This method is used to create employee.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CreateEmployeeModel?> Execute(CreateEmployeeModel model)
        {
            if (model == null || !string.IsNullOrEmpty(_db.Employees.FirstOrDefault(e => e.Email == model.Email)?.Email))
                return null;
            decimal? bonusValidation = _db.Salaries.FirstOrDefault(s => s.Role == Parameters.HR_AND_SALES)?.Bonus;
            model.Salary = model.Position switch
            {
                JobPosition.Developer => model.Salary + (model.Salary * (_db.Salaries.FirstOrDefault(s => s.Role == Parameters.DEVELOPERS)?.Bonus / 100)),
                JobPosition.Manager => model.Salary +  (model.Salary * (_db.Salaries.FirstOrDefault(s => s.Role == Parameters.MANAGERS)?.Bonus / 100)),
                _ => bonusValidation == 0 ? model.Salary : model.Salary + (model.Salary * (bonusValidation/ 100)),
            };
            model.CreationDate = DateTime.UtcNow;
            model.ModificationDate = DateTime.UtcNow;
            await _db.Employees.AddAsync(_mapper.Map<EmployeeEntity>(model));
            await _db.SaveAsync();
            return model;
        }
    }
}
