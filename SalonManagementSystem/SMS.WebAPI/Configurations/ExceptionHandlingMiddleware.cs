using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using Microsoft.Azure.Cosmos;

namespace SMS.WebAPI.Configurations
{
    public static class ExceptionHandlingMiddleware
    {
        public class GlobalExceptionMiddleware
        {
            private readonly RequestDelegate _next;

            public GlobalExceptionMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                try
                {
                    await _next(context);
                }
                catch(CosmosException ex)
                {
                    await HandleExceptionAsync(context, ex);
                }
             
                catch (Exception ex)
                {
                    await HandleExceptionAsync(context, ex);
                }
            }

            private Task HandleExceptionAsync(HttpContext context, Exception ex)
            {
                context.Response.ContentType = "application/json";
                var errorResponse = new
                {
                    message = ex.Message,
                    exceptionType = ex.GetType().Name,
                    Timestamp = DateTime.UtcNow,
                    stackTrace = ex.StackTrace
                };

                return context.Response.WriteAsJsonAsync(errorResponse);
            }
        }

    }
}
