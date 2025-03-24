namespace EmployeeManagement.Application.Database.Department.Commands.UpdateDepartment
{
    public interface IUpdateDepartmentCommand
    {
        /// <summary>
        /// This method is used to update department.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Execute(UpdateDepartmentModel model);
    }
}
