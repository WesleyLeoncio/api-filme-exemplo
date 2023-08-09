using System.Text.Json;

namespace api_filme_exemplo.Infra.Exceptions;

public class ErrorExceptionResult
{
    public HttpContext Context { get; set; }
    public string Msg { get; set; }
    public Type ExceptionType { get; set; }

    public ErrorExceptionResult(HttpContext context, Exception exception)
    {
        Context = context;
        Msg = exception.Message;
        ExceptionType = exception.GetType();
    }

    public Task GetResultPadrao()
    {
        string msg = "Aconteceu um erro desconhecido, entre em contado com nosso suporte.";
        int status = 500;
        string result = JsonSerializer.Serialize(new { status , mensage = msg});
        Context.Response.StatusCode = status;
        return Context.Response.WriteAsync(result);
    }
}