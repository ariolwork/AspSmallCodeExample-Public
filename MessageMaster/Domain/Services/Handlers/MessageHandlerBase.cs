using MessageMaster.Domain.Models.Core.Message;
using MessageMaster.Domain.Services.Handlers.Register;

namespace MessageMaster.Domain.Services.Handlers
{
    public abstract class MessageHandlerBase<T> : IMessageHandler<T> where T : MessageBase
    {
        private readonly SemaphoreSlim _semaphore;


        protected MessageHandlerBase(HandlerOptions options)
        {
            _semaphore = new SemaphoreSlim(options.MaxParallelLevel);
        }

        public async Task<string> HandleAsync(T message)
        {
            await _semaphore.WaitAsync();
            try
            {
                return await HandleCoreAsync(message);
            }
            finally
            {
                _semaphore.Release();
            }
        }
        
        protected abstract Task<string> HandleCoreAsync(T message);
    }
}
