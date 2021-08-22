using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OnionArch.Application.Exceptions;
using System.Threading.Tasks;

namespace OnionArch.WebApi.Middleware
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

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next.Invoke(httpContext);
            }
            catch (ValidationException ex)
            {
                logger.LogError(ex.Message);
            }
        }
    }
}
