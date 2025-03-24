using AutoMapper;
using EmployeeManagement.Application.Configuration;
using EmployeeManagement.Application.Database.Department.Commands.CreateDepartment;
using EmployeeManagement.Application.Database.Department.Commands.DeleteDepartment;
using EmployeeManagement.Application.Database.Department.Commands.UpdateDepartment;
using EmployeeManagement.Application.Database.Department.Queries.GetAllDepartments;
using EmployeeManagement.Application.Database.Department.Queries.GetDepartmentByName;
using EmployeeManagement.Application.Database.Employee.Commands.CreateEmployee;
using EmployeeManagement.Application.Database.Employee.Commands.DeleteEmployee;
using EmployeeManagement.Application.Database.Employee.Commands.UpdateEmployee;
using EmployeeManagement.Application.Database.Employee.Queries.GetAllEmployees;
using EmployeeManagement.Application.Database.Employee.Queries.GetEmployeeByEmail;
using EmployeeManagement.Application.Validators.Department;
using EmployeeManagement.Application.Validators.Employee;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Application.DIConfiguration
{
    public static class DependencyInjectionService
    {
        /// <summary>
        /// DI Constructor to Application Layer.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            #region Mapper Repositories
            MapperConfiguration mapper = new(config =>
            {
                config.AddProfile(new MapperProfile());
            });
            services.AddSingleton(mapper.CreateMapper());
            #endregion
            #region Employees Repositories
            services.AddTransient<ICreateEmployeeCommand, CreateEmployeeCommand>();
            services.AddTransient<IDeleteEmployeeCommand, DeleteEmployeeCommand>();
            services.AddTransient<IUpdateEmployeeCommand, UpdateEmployeeCommand>();
            services.AddTransient<IGetAllEmployeesQuery, GetAllEmployeesQuery>();
            services.AddTransient<IGetEmployeeByEmailQuery, GetEmployeeByEmailQuery>();
            #endregion
            #region Departments Repositories
            services.AddTransient<ICreateDepartmentCommand, CreateDepartmentCommand>();
            services.AddTransient<IDeleteDepartmentCommand, DeleteDepartmentCommand>();
            services.AddTransient<IUpdateDepartmentCommand, UpdateDepartmentCommand>();
            services.AddTransient<IGetAllDepartmentsQuery, GetAllDepartmentsQuery>();
            services.AddTransient<IGetDepartmentByNameQuery, GetDepartmentByNameQuery>();
            #endregion
            #region Employees Validator
            services.AddScoped<IValidator<CreateEmployeeModel>, CreateEmployeeValidator>();
            services.AddScoped<IValidator<UpdateEmployeeModel>, UpdateEmployeeValidator>();
            #endregion
            #region Departments Validator
            services.AddScoped<IValidator<CreateDepartmentModel>, CreateDepartmentValidator>();
            services.AddScoped<IValidator<UpdateDepartmentModel>, UpdateDepartmentValidator>();
            #endregion
            return services;
        }
    }
}
