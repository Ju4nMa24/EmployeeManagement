using EmployeeManagement.Domain.Entities.Department;

namespace EmployeeManagement.Application.Database.Department.Commands.DeleteDepartment
{
    /// <summary>
    /// DI Constructor.
    /// </summary>
    /// <param name="db"></param>
    public class DeleteDepartmentCommand(IDataBaseService db) : IDeleteDepartmentCommand
    {
        private readonly IDataBaseService _db = db;
        /// <summary>
        /// This method is used to delete Department.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<bool> Execute(string name)
        {
            DepartmentEntity? department = _db.Departments.FirstOrDefault(e => e.Name == name);
            if (department == null || string.IsNullOrEmpty(name))
                return false;

            _db.Departments.Remove(department);
            return await _db.SaveAsync();
        }
    }
}
