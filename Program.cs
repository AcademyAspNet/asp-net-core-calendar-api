using MiddlewareExampleWebAPI.Middleware;
using System.Diagnostics;
using System.Net;

namespace MiddlewareExampleWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseApiKeyValidation();

            app.Use(async (context, next) =>
            {
                Console.WriteLine("Начинаем обработку запроса (Middleware 1)...");
                await next(context);
                Console.WriteLine("Заканчиваем обработку запроса (Middleware 1)...");
            });

            app.Use(async (context, next) =>
            {
                Console.WriteLine("Начинаем обработку запроса (Middleware 2)...");
                await next(context);
                Console.WriteLine("Заканчиваем обработку запроса (Middleware 2)...");
            });

            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}
