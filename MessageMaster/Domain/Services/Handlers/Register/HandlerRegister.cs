using MessageMaster.Domain.Models.Core.Message;
using MessageMaster.Domain.Services.Handlers.Fabric;

namespace MessageMaster.Domain.Services.Handlers.Register
{
    public static class HandlerRegister
    {
        public static IServiceCollection AddHandlers(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddScoped<SumTwoNumbersMessageHandler>((o) =>
            {
                var options = configuration.GetSection($"Handlers:{typeof(SumTwoNumbersMessageHandler).Name}").Get<HandlerOptions>();
                return new SumTwoNumbersMessageHandler(options);
            });
            services.AddScoped<WordsReverseMessageHandler>((o) =>
            {
                var options = configuration.GetSection($"Handlers:{typeof(WordsReverseMessageHandler).Name}").Get<HandlerOptions>();
                return new WordsReverseMessageHandler(options);
            });
            services.AddScoped<WordsCounterMessageHandler>((o) =>
            {
                var options = configuration.GetSection($"Handlers:{typeof(WordsCounterMessageHandler).Name}").Get<HandlerOptions>();
                return new WordsCounterMessageHandler(options);
            });
            services.AddSingleton<IHandlersFabric<StringMessage>, StringMessageHadlersFabric>((o) =>
            {
                var scope = o.CreateScope().ServiceProvider;
                return new StringMessageHadlersFabric(
                    scope.GetRequiredService<SumTwoNumbersMessageHandler>(),
                    scope.GetRequiredService<WordsCounterMessageHandler>(),
                    scope.GetRequiredService<WordsReverseMessageHandler>());
            });
            return services;
        }
    }
}
