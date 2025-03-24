using EmployeeManagement.Application.Database.Employee.Commands.CreateEmployee;
using EmployeeManagement.Application.Database.Employee.Commands.DeleteEmployee;
using EmployeeManagement.Application.Database.Employee.Commands.UpdateEmployee;
using EmployeeManagement.Application.Database.Employee.Queries.GetAllEmployees;
using EmployeeManagement.Application.Database.Employee.Queries.GetEmployeeByEmail;
using EmployeeManagement.Application.Features;
using EmployeeManagement.Common.Constants;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/v1/Employee")]
    [ApiController]
    //[TypeFilter(typeof(ExceptionManager))]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// This method is used to register Employee.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody]CreateEmployeeModel model, [FromServices]ICreateEmployeeCommand command, [FromServices] IValidator<CreateEmployeeModel> validator)
        {
            ValidationResult validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, Errors.FAILED_WITH_DESCRIPTION, validate.Errors));

            CreateEmployeeModel? result = await command.Execute(model);

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status201Created, Correct.SUCCESSFULLY, result));
        }
        /// <summary>
        /// This method is used to update Employee.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPatch("update")]
        public async Task<ActionResult> Update([FromBody]UpdateEmployeeModel model, [FromServices]IUpdateEmployeeCommand command, [FromServices] IValidator<UpdateEmployeeModel> validator)
        {
            ValidationResult validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, Errors.FAILED_WITH_DESCRIPTION, validate.Errors));

            bool result = await command.Execute(model);

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, Correct.SUCCESSFULLY_UPDATE, result));
        }
        /// <summary>
        /// This method is used to delete Employee.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("delete/{email}")]
        public async Task<ActionResult> Delete(string email, [FromServices]IDeleteEmployeeCommand command)
        {
            if (email is null)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, Errors.FAILED_WITH_DESCRIPTION, null));

            bool result = await command.Execute(email);
            if (!result)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, Errors.FAILED, result));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, Correct.SUCCESSFULLY_DELETED, result));
        }

        /// <summary>
        /// This method is used to get all Employees.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpGet("get_all_employees")]
        public async Task<ActionResult> GetAllEmployees([FromServices]IGetAllEmployeesQuery command)
        {
            IEnumerable<GetAllEmployeesModel>? result = await command.Execute();
            if (result is null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, Errors.FAILED, result));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, Correct.SUCCESSFULLY, result));
        }

        /// <summary>
        /// This method is used to get Employee by email.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpGet("get_employee_by_email/{email}")]
        public async Task<ActionResult> GetEmployeeByEmail(string email, [FromServices]IGetEmployeeByEmailQuery command)
        {
            GetEmployeeByEmailModel? result = await command.Execute(email);
            if (result is null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, Errors.FAILED, result));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, Correct.SUCCESSFULLY, result));
        }
    }
}
