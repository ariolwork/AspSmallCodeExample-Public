using MessageMaster.Application;
using MessageMaster.Domain.Services;
using MessageMaster.Domain.Services.Handlers.Register;
using MessageMaster.Infrastructure.Middlewares;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        //add application services
        services.AddScoped<IRequestHandler, MessagesRequestHandler>();
        services.AddScoped<IMessageRequestHandler, MessageRequestHandler>();
        services.AddHandlers(_configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        //dev
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        //add middlewares
        app.UseMiddleware<ExceptionHandlerMiddleware>();
        app.UseMiddleware<RequestHandlerMiddleware>();
    }
}