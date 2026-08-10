using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace NZwalks.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                var errorId = Guid.NewGuid();
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var errorResponse = new
                {
                    Id = errorId,
                    Message = "Something went wrong! We are looking into it."
                };

                await httpContext.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
