namespace api_filme_exemplo.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(String msg) : base(msg){}
}