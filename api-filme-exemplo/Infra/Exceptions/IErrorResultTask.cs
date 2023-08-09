namespace api_filme_exemplo.Exceptions;

public interface IErrorResultTask
{
    public Task? ValidarException(ErrorExceptionResult error);
}