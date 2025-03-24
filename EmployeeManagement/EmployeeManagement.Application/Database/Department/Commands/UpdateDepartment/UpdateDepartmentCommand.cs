using AutoMapper;
using EmployeeManagement.Domain.Entities.Department;

namespace EmployeeManagement.Application.Database.Department.Commands.UpdateDepartment
{
    /// <summary>
    /// DI Constructor.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="mapper"></param>
    public class UpdateDepartmentCommand(IDataBaseService db, IMapper mapper) : IUpdateDepartmentCommand
    {
        private readonly IDataBaseService _db = db;
        private readonly IMapper _mapper = mapper;
        /// <summary>
        /// This method is used to update employee.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Execute(UpdateDepartmentModel model)
        {
            DepartmentEntity? department = await _db.Departments.FindAsync(model.Id);
            if (department is not null)
            {
                department.Name = model.Name;
                department.ModificationDate = DateTime.UtcNow;
                _db.Departments.Update(department);
                await _db.SaveAsync();
                return true;
            }
            return false;
        }
    }
}
