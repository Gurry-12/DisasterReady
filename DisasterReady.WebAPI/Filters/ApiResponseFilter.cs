using DisasterReady.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DisasterReady.WebAPI.Filters
{
    public class ApiResponseFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.Result is ObjectResult obj &&
                obj.Value != null &&
                obj.Value.GetType().IsGenericType &&
                obj.Value.GetType().GetGenericTypeDefinition() == typeof(DisasterReady.Application.Common.Result<>))
            {
                var type = obj.Value.GetType();
                var isSuccess = (bool)type.GetProperty("IsSuccess").GetValue(obj.Value);
                var value = type.GetProperty("Value").GetValue(obj.Value);
                var errors = (List<string>)type.GetProperty("Errors").GetValue(obj.Value);
                int statusCode = (int)type.GetProperty("StatusCode").GetValue(obj.Value);

                context.Result = isSuccess
                    ? new ObjectResult(ApiResponse.Success(value)) { StatusCode = statusCode }
                    : new ObjectResult(ApiResponse.Failure(errors)) { StatusCode = statusCode };
            }

            await next();
        }
    }
}
