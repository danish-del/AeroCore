using Serilog;
using System.Net;
using System.Text.Json;

namespace AeroCore.API.Middlewares
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler>
            logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                context.Response.StatusCode = (int)
                HttpStatusCode.InternalServerError;
                var response = new
                {
                    Success = false,
                    message = ex.Message
                };
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
              
            }
                
        }
    }
}
