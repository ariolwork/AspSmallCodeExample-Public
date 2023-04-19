namespace MessageMaster.Domain.Models.Exceptions.Internal;

public class UnexpectedMessageForHandlerException : InternalExceptionBase
{
    public UnexpectedMessageForHandlerException(string? message) : base(message)
    {
    }
}
