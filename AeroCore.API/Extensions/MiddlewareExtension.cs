using AeroCore.API.Middlewares;

namespace AeroCore.API.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this
            IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}
