using EmployeeManagement.Domain.Models;
using EmployeeManagement.Application.Features;
using Newtonsoft.Json;
using System.Net;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;

namespace EmployeeManagement.Application.Exceptions
{
    public class ExceptionManager : IExceptionFilter
    {
        public bool AllowMultiple => throw new NotImplementedException();

        /// <summary>
        /// This method is used to exceptions.
        /// </summary>
        /// <param name="context"></param>
        public static void OnException(ExceptionContext context)
        {
            BaseResponseModel result = ResponseApiService.Response((int)HttpStatusCode.InternalServerError, context.Exception.Message, null);
            context.ActionContext.Response.StatusCode = (HttpStatusCode)result.StatusCode;
            result.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.Content = new StringContent(JsonConvert.SerializeObject(new
            {
                result.Message,
                result.Success,
                result.StatusCode,
                result.Data
            }));
        }

        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            BaseResponseModel result = ResponseApiService.Response((int)HttpStatusCode.InternalServerError, actionExecutedContext.Exception.Message, null);
            actionExecutedContext.ActionContext.Response.StatusCode = (HttpStatusCode)result.StatusCode;
            result.StatusCode = (int)HttpStatusCode.InternalServerError;
            actionExecutedContext.Response.Content = new StringContent(JsonConvert.SerializeObject(new
            {
                result.Message,
                result.Success,
                result.StatusCode,
                result.Data
            }));
            return Task.Run(() => actionExecutedContext);
        }
    }
}
