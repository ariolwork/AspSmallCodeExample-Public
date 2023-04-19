using MessageMaster.Domain.Models.Core.Message;
using MessageMaster.Domain.Services.Handlers.Register;

namespace MessageMaster.Domain.Services.Handlers
{
    public class WordsCounterMessageHandler : MessageHandlerBase<StringMessage>
    {
        public WordsCounterMessageHandler(HandlerOptions options) : base(options) {}

        protected override Task<string> HandleCoreAsync(StringMessage message)
        {
            return Task.FromResult(message.Content.Count(c => c == ' ').ToString());
        }
    }
}
