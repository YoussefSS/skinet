using System.Net;
using System.Text.Json;
using API.Errors;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        // RequestDelegate is a function that can process HTTP requests
        // env allows us to see whether we are in development mode or not
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
        }

        // Middleware function
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // this means if there's no exception, then the request moves on to the next stage
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message); // console
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // 500

                var response = _env.IsDevelopment() ?
                    new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString()) // in development mode
                    : new ApiException((int)HttpStatusCode.InternalServerError); // production

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options); // we are not in the context of a Controller, so this will not be auto formatter into the CamelCase Json convention, we need to use options

                await context.Response.WriteAsync(json);
            }
        }
    }
}