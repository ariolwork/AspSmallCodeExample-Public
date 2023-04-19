using MessageMaster.Domain.Models.Core.Message;
using MessageMaster.Domain.Models.Exceptions.Internal;
using MessageMaster.Domain.Services.Handlers.Register;

namespace MessageMaster.Domain.Services.Handlers
{
    public class SumTwoNumbersMessageHandler : MessageHandlerBase<StringMessage>
    {
        public SumTwoNumbersMessageHandler(HandlerOptions options) : base(options) {}

        protected override Task<string> HandleCoreAsync(StringMessage message)
        {
            var nums = message.Content.Split('+').ToList().Select(i =>
            {
                if(!long.TryParse(i, out var value))
                {
                    throw new UnexpectedMessageForHandlerException("Expected two decimal numbers");
                }
                return value;
            }).ToArray();
            if(nums.Count() > 2)
            {
                throw new UnexpectedMessageForHandlerException("Expected two decimal numbers");
            }
            return Task.FromResult(nums.Sum().ToString());
        }
    }
}
