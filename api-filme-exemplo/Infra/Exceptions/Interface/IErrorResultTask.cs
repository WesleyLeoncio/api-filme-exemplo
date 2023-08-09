namespace api_filme_exemplo.Infra.Exceptions.Interface;

public interface IErrorResultTask
{
    public Task? ValidarException(ErrorExceptionResult error);
}