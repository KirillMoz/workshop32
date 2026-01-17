using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using StartAppMVC.Models.Db;
using StartAppMVC.Models;

namespace StartAppMVC.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context, IRequestLogRepository repository)
        {
            // Создаем объект запроса
            var request = new Request
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = $"http://{context.Request.Host.Value + context.Request.Path}"
            };

            // Логируем в консоль
            Console.WriteLine($"[{request.Date}]: New request to {request.Url}");

            // Сохраняем в базу данных
            await repository.AddRequest(request);

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
