using AutoMapper;
using EmployeeManagement.Domain.Entities.Department;

namespace EmployeeManagement.Application.Database.Department.Commands.CreateDepartment
{
    /// <summary>
    /// DI Constructor.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="mapper"></param>
    public class CreateDepartmentCommand(IDataBaseService db, IMapper mapper) : ICreateDepartmentCommand
    {
        private readonly IDataBaseService _db = db;
        private readonly IMapper _mapper = mapper;
        /// <summary>
        /// This method is used to create department.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CreateDepartmentModel?> Execute(CreateDepartmentModel model)
        {
            if (model == null || !string.IsNullOrEmpty(_db.Departments.FirstOrDefault(e => e.Name == model.Name)?.Name))
                return null;

            model.CreationDate = DateTime.UtcNow;
            model.ModificationDate = DateTime.UtcNow;
            await _db.Departments.AddAsync(_mapper.Map<DepartmentEntity>(model));
            await _db.SaveAsync();
            return model;
        }
    }
}
