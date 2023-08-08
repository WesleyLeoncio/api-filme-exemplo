using System.Data;
using System.Net;
using System.Text.Json;
using api_filme_exemplo.Exceptions;

namespace api_filme_exemplo.Middlewares;

public class GlobalErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    
    public GlobalErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var exceptionType = exception.GetType();

        if (exceptionType == typeof(NotFoundException))
        {
            return Result(context, (int)HttpStatusCode.NotFound, exception.Message);
        }else if (exceptionType == typeof(DBConcurrencyException))
        {
            return Result(context, (int)HttpStatusCode.NotFound, exception.Message);
        }
        
        return Result(context,(int)HttpStatusCode.InternalServerError,exception.Message);

    }

    private static Task Result(HttpContext context, int status, string msg)
    {
        string result = JsonSerializer.Serialize(new { status, msg});
        context.Response.StatusCode = status;
        return context.Response.WriteAsync(result);
    }
}