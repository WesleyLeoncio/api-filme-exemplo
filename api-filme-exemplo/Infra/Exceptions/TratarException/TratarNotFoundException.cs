using System.Text.Json;
using api_filme_exemplo.Exceptions;

namespace api_filme_exemplo.Infra.Exceptions.TratarException;

public class TratarNotFoundException : IErrorResultTask
{
    public Task? ValidarException(ErrorExceptionResult error)
    {
        if (error.ExceptionType == typeof(NotFoundException))
        {
            int status = 404;
            string result = JsonSerializer.Serialize(new { status, mensage = error.Msg});
            error.Context.Response.StatusCode = status;
            return error.Context.Response.WriteAsync(result);
        }

        return null;
    }
}