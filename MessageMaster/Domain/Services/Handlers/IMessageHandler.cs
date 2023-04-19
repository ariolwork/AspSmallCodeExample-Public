using MessageMaster.Domain.Models.Core.Message;

namespace MessageMaster.Domain.Services.Handlers
{
    public interface IMessageHandler<T> where T : MessageBase
    {
        Task<string> HandleAsync(T message);
    }
}
