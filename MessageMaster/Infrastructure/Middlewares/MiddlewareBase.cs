namespace MessageMaster.Infrastructure.Middlewares
{
    public abstract class MiddlewareBase
    {
        protected readonly RequestDelegate _next;

        public MiddlewareBase(RequestDelegate next)
        {
            _next = next;
        }
    }
}
