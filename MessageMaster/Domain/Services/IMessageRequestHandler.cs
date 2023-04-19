using MessageMaster.Domain.Models.Core.Message;

namespace MessageMaster.Domain.Services
{
    public interface IMessageRequestHandler
    {
        Task<string> ProcessAsync(StringMessage message);
    }
}