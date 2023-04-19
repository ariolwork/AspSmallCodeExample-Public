using MessageMaster.Domain.Models.Core.Message;

namespace MessageMaster.Domain.Services.Handlers.Fabric
{
    public interface IHandlersFabric<T> where T: MessageBase
    {
        IMessageHandler<T> GetMessageHandler(T message);
    }
}
