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

            public LoggingMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task InvokeAsync(HttpContext context, IRequestRepository repository)
            {
                try
                {
                    // Создаем объект запроса
                    var requestLog = new Request
                    {
                        Id = Guid.NewGuid(),
                        Date = DateTime.Now,
                        Url = FormatRequestUrl(context.Request)
                    };

                    // Логируем в консоль для отладки
                    Console.WriteLine($"[{requestLog.Date:yyyy-MM-dd HH:mm:ss}] {requestLog.Url}");

                    // Сохраняем в базу данных
                    await repository.AddRequest(requestLog);
                }
                catch (Exception ex)
                {
                    // Логируем ошибку, но не прерываем выполнение
                    Console.WriteLine($"Ошибка при логировании запроса: {ex.Message}");
                }

                // Передача запроса далее по конвейеру
                await _next.Invoke(context);
            }

            private string FormatRequestUrl(HttpRequest request)
            {
                // Форматируем URL: Метод + Хост + Путь + QueryString
                var url = $"{request.Method} {request.Scheme}://{request.Host}{request.Path}";

                if (!string.IsNullOrEmpty(request.QueryString.Value))
                {
                    url += request.QueryString.Value;
                }

                return url;
            }
        
    }
}
