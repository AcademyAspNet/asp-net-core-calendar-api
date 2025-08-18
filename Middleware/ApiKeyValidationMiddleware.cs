using Microsoft.AspNetCore.Builder;

namespace MiddlewareExampleWebAPI.Middleware
{
    public class ApiKeyValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _validApiKey = "calendar";

        public ApiKeyValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string? apiKey = context.Request.Headers["X-API-Key"];

            if (string.IsNullOrEmpty(apiKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("API ключ не указан!");

                return;
            }

            if (apiKey != _validApiKey)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Некорректный API ключ");

                return;
            }

            await _next(context);
        }
    }

    public static class ApiKeyValidationMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiKeyValidation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiKeyValidationMiddleware>();
        }
    }
}
