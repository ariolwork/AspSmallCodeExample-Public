namespace MessageMaster.Application
{
    public interface IRequestHandler
    {
        Task<IResult> ProcessAsync(HttpRequest context);
    }
}
