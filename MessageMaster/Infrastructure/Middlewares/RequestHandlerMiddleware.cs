using MessageMaster.Application;

namespace MessageMaster.Infrastructure.Middlewares
{
    public class RequestHandlerMiddleware : MiddlewareBase
    {
        public RequestHandlerMiddleware(RequestDelegate next) : base(next){}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="handler">На случай, если нам нужен Scoped handler. В противном 
        /// случае нужно передавать через конструктор и он будет singletone</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task InvokeAsync(HttpContext context, IRequestHandler handler)
        {
            var result = await handler.ProcessAsync(context.Request);
            await result.ExecuteAsync(context);
        }
    }
}
