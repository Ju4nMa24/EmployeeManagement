using AutoMapper;
using EmployeeManagement.Domain.Entities.Employee;

namespace EmployeeManagement.Application.Database.Employee.Commands.UpdateEmployee
{
    /// <summary>
    /// DI Constructor.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="mapper"></param>
    public class UpdateEmployeeCommand(IDataBaseService db, IMapper mapper) : IUpdateEmployeeCommand
    {
        private readonly IDataBaseService _db = db;
        private readonly IMapper _mapper = mapper;
        /// <summary>
        /// This method is used to update employee.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Execute(UpdateEmployeeModel model)
        {
            EmployeeEntity? result = _db.Employees.FirstOrDefault(e => e.Email == model.OldEmail);
            if (result is not null)
            {
                _mapper.Map(model, result);
                result.ModificationDate = DateTime.UtcNow;
                result.CreationDate = result.CreationDate;
                result.Email = model.NewEmail == result.Email || string.IsNullOrEmpty(model.NewEmail) ? model.OldEmail : model.NewEmail;
                _db.Employees.Update(result);
                await _db.SaveAsync();
                return true;
            }
            return false;
        }
    }
}
