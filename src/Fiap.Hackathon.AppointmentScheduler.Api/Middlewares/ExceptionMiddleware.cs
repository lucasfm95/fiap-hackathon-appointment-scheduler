using System.Net;
using System.Text.Json;

namespace Fiap.Hackathon.AppointmentScheduler.Api.Middlewares;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex, logger);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger<ExceptionMiddleware> logger)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        logger.LogError($"Error: {exception.Message}");
        
        return context.Response.WriteAsync(JsonSerializer.Serialize(new
        {
            context.Response.StatusCode,
            Message = "We have some problems, please try again later.",
        } ));
    }
}