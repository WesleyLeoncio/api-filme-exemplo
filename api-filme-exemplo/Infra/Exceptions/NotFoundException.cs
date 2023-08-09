namespace api_filme_exemplo.Infra.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(String msg) : base(msg){}
}