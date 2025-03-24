namespace EmployeeManagement.Application.Database.Department.Commands.DeleteDepartment
{
    public interface IDeleteDepartmentCommand
    {
        /// <summary>
        /// This method is used to delete Department.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<bool> Execute(string name);
    }
}
