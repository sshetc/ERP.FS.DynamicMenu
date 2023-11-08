using System.Net;
using System.Text.Json;
using FluentValidation;
using DynamicMenu.Application.Common.Exceptions;

namespace DynamicMenu.WebApi.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomExceptionHandlerMiddleware(RequestDelegate next) => _next = next;
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (exception) 
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case NotFoundException notFoundException:
                    code = HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize(new { message = notFoundException.Message });
                    break;
                case NotUrlException notUrlException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(new { message = notUrlException.Message });
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (string.IsNullOrEmpty(result))
            {
                result = JsonSerializer.Serialize(new { message = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}
