using MessageMaster.Domain.Models.Core.Message;
using MessageMaster.Domain.Services.Handlers.Register;

namespace MessageMaster.Domain.Services.Handlers
{
    public class WordsReverseMessageHandler : MessageHandlerBase<StringMessage>
    {
        public WordsReverseMessageHandler(HandlerOptions options) : base(options) {}

        protected override Task<string> HandleCoreAsync(StringMessage message)
        {
            return Task.FromResult(string.Join(' ', message.Content.Split(' ').Reverse()));
        }
    }
}
