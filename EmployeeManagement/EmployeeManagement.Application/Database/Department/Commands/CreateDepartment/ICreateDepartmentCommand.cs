namespace EmployeeManagement.Application.Database.Department.Commands.CreateDepartment
{
    public interface ICreateDepartmentCommand
    {
        /// <summary>
        /// This method is used to create department.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<CreateDepartmentModel?> Execute(CreateDepartmentModel model);
    }
}
