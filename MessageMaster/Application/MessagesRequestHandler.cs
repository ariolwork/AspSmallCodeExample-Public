using MessageMaster.Domain.Models.Core.Message;
using MessageMaster.Domain.Services;
using System.ComponentModel.DataAnnotations;

namespace MessageMaster.Application
{
    public class MessagesRequestHandler : IRequestHandler
    {
        private const string MESSAGEIDKEY = "Id";
        private readonly IMessageRequestHandler _messageHandler; 

        public MessagesRequestHandler(IMessageRequestHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }

        public async Task<IResult> ProcessAsync(HttpRequest context)
        {
            var message = await ReadMessageAsync(context);
            return Results.Ok(await _messageHandler.ProcessAsync(message));
        }

        private async Task<StringMessage> ReadMessageAsync(HttpRequest context)
        {
            if (!context.Headers.TryGetValue(MESSAGEIDKEY, out var idString))
                throw new BadHttpRequestException("Message Id is not set");

            if (!long.TryParse(idString, out var id))
                throw new ValidationException("Message Id is not correct"); 

            var content = string.Empty;
            using (StreamReader reader = new StreamReader(context.Body, System.Text.Encoding.UTF8))
            {
                content = await reader.ReadToEndAsync();
            }

            if(string.IsNullOrEmpty(content))
                throw new ValidationException("Message is empty");

            return new StringMessage(id, content);
        }
    }
}
