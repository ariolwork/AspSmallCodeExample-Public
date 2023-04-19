namespace MessageMaster.Domain.Models.Exceptions.Internal;

public abstract class InternalExceptionBase : Exception
{
    protected InternalExceptionBase(string? message) : base(message)
    {
    }
    protected InternalExceptionBase() { }
}
