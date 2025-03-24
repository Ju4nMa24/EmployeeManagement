using AutoMapper;
using EmployeeManagement.Application.Database.Department.Commands.CreateDepartment;
using EmployeeManagement.Application.Database.Department.Commands.UpdateDepartment;
using EmployeeManagement.Application.Database.Department.Queries.GetAllDepartments;
using EmployeeManagement.Application.Database.Employee.Commands.CreateEmployee;
using EmployeeManagement.Application.Database.Employee.Commands.UpdateEmployee;
using EmployeeManagement.Application.Database.Employee.Queries.GetAllEmployees;
using EmployeeManagement.Application.Database.Employee.Queries.GetEmployeeByEmail;
using EmployeeManagement.Domain.Entities.Department;
using EmployeeManagement.Domain.Entities.Employee;

namespace EmployeeManagement.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            #region Maps to Employees
            CreateMap<EmployeeEntity, CreateEmployeeModel>().ReverseMap();
            CreateMap<EmployeeEntity, UpdateEmployeeModel>().ReverseMap();
            CreateMap<EmployeeEntity, GetAllEmployeesModel>().ReverseMap();
            CreateMap<EmployeeEntity, GetEmployeeByEmailModel>().ReverseMap();
            #endregion
            #region Maps to Departments
            CreateMap<DepartmentEntity, CreateDepartmentModel>().ReverseMap();
            CreateMap<DepartmentEntity, UpdateDepartmentModel>().ReverseMap();
            CreateMap<DepartmentEntity, GetAllDepartmentsModel>().ReverseMap();
            CreateMap<DepartmentEntity, GetEmployeeByEmailModel>().ReverseMap();
            #endregion
        }
    }
}
