using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Application.Features
{
    public static class ResponseApiService
    {
        /// <summary>
        /// This method is used to generate response in APIs.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static BaseResponseModel Response(int statusCode, string message = "", object? data = null)
        {
            bool success = false;
            if (statusCode >= 200 && statusCode < 300)
                success = true;

            return new()
            {
                Message = message,
                Data = data,
                Success = success,
                StatusCode = statusCode
            };
        }
    }
}
