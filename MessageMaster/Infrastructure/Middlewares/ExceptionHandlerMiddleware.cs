using MessageMaster.Domain.Models.Exceptions.Internal;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace MessageMaster.Infrastructure.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (BadHttpRequestException exception)
            {
                await WriteResponseAsync(context, StatusCodes.Status400BadRequest, exception.Message);
            }
            catch (ValidationException exception)
            {
                await WriteResponseAsync(context, StatusCodes.Status400BadRequest, exception.Message);
            }
            catch (InternalExceptionBase exception)
            {
                // можно добавить еще какую нибудь обработку на управляемые ошибки
                _logger.LogError(exception.StackTrace);
                await WriteResponseAsync(context, StatusCodes.Status500InternalServerError, exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.StackTrace);
                await WriteResponseAsync(context, StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        private static async Task WriteResponseAsync(HttpContext context, int code, string message)
        {
            context.Response.StatusCode = code;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(new ProblemDetails()
            {
                Status = context.Response.StatusCode,
                Title = message
            }));
        }
    }
}
