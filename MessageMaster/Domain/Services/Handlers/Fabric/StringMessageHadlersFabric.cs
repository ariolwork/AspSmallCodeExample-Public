using MessageMaster.Domain.Models.Core.Message;

namespace MessageMaster.Domain.Services.Handlers.Fabric
{
    public class StringMessageHadlersFabric : IHandlersFabric<StringMessage>
    {
        private readonly SumTwoNumbersMessageHandler _sumTwoNumbersMessageHandler;
        private readonly WordsCounterMessageHandler _wordsCounterMessageHandler;
        private readonly WordsReverseMessageHandler _wordsReverseMessageHandler;

        public StringMessageHadlersFabric(
            SumTwoNumbersMessageHandler sumTwoNumbersMessageHandler,
            WordsCounterMessageHandler wordsCounterMessageHandler,
            WordsReverseMessageHandler wordsReverseMessageHandler)
        {
            _sumTwoNumbersMessageHandler = sumTwoNumbersMessageHandler;
            _wordsCounterMessageHandler = wordsCounterMessageHandler;
            _wordsReverseMessageHandler = wordsReverseMessageHandler;
        }


        public IMessageHandler<StringMessage> GetMessageHandler(StringMessage message)
        {
            var words = message.Content.Split(' ').ToArray();
            if (words.Count() > 5)
                return _wordsCounterMessageHandler;
            if (words[0].Contains('+'))
                return _sumTwoNumbersMessageHandler;
            return _wordsReverseMessageHandler;
        }
    }
}
