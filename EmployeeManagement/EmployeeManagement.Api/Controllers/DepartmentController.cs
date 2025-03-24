using EmployeeManagement.Application.Database.Department.Commands.CreateDepartment;
using EmployeeManagement.Application.Database.Department.Commands.DeleteDepartment;
using EmployeeManagement.Application.Database.Department.Commands.UpdateDepartment;
using EmployeeManagement.Application.Database.Department.Queries.GetAllDepartments;
using EmployeeManagement.Application.Database.Department.Queries.GetDepartmentByName;
using EmployeeManagement.Application.Features;
using EmployeeManagement.Common.Constants;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/v1/Department")]
    [ApiController]
    //[TypeFilter(typeof(ExceptionManager))]
    public class DepartmentController : ControllerBase
    {
        /// <summary>
        /// This method is used to register department.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody]CreateDepartmentModel model, [FromServices]ICreateDepartmentCommand command, [FromServices] IValidator<CreateDepartmentModel> validator)
        {
            ValidationResult validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, Errors.FAILED_WITH_DESCRIPTION, validate.Errors));

            CreateDepartmentModel? result = await command.Execute(model);

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status201Created, Correct.SUCCESSFULLY, result));
        }
        /// <summary>
        /// This method is used to update department.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPatch("update")]
        public async Task<ActionResult> Update([FromBody]UpdateDepartmentModel model, [FromServices]IUpdateDepartmentCommand command, [FromServices]IValidator<UpdateDepartmentModel> validator)
        {
            ValidationResult validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, Errors.FAILED_WITH_DESCRIPTION, validate.Errors));

            bool result = await command.Execute(model);

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, Correct.SUCCESSFULLY_UPDATE, result));
        }
        /// <summary>
        /// This method is used to delete department.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("delete/{name}")]
        public async Task<ActionResult> Delete(string name, [FromServices]IDeleteDepartmentCommand command)
        {
            if (name is null)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, Errors.FAILED_WITH_DESCRIPTION, null));

            bool result = await command.Execute(name);
            if (!result)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, Errors.FAILED, result));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, Correct.SUCCESSFULLY_DELETED, result));
        }

        /// <summary>
        /// This method is used to get all departments.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpGet("get_all_departments")]
        public async Task<ActionResult> GetAllDepartments([FromServices]IGetAllDepartmentsQuery command)
        {
            List<GetAllDepartmentsModel>? result = await command.Execute();
            if (result is null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, Errors.FAILED, result));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, Correct.SUCCESSFULLY, result));
        }

        /// <summary>
        /// This method is used to get department by name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpGet("get_department_by_name/{name}")]
        public async Task<ActionResult> GetDepartmentByName(string name, [FromServices]IGetDepartmentByNameQuery command)
        {
            GetDepartmentByNameModel? result = await command.Execute(name);
            if (result is null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, Errors.FAILED, result));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, Correct.SUCCESSFULLY, result));
        }
    }
}
