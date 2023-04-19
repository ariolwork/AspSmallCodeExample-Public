using MessageMaster.Domain.Models.Core.Message;
using MessageMaster.Domain.Services.Handlers.Fabric;

namespace MessageMaster.Domain.Services
{
    public class MessageRequestHandler : IMessageRequestHandler
    {
        private readonly IHandlersFabric<StringMessage> handlersFabric;

        public MessageRequestHandler(IHandlersFabric<StringMessage> handlersFabric)
        {
            this.handlersFabric = handlersFabric;
        }

        public Task<string> ProcessAsync(StringMessage message)
        {
            var handler = handlersFabric.GetMessageHandler(message);
            return handler.HandleAsync(message);
        }
    }
}
