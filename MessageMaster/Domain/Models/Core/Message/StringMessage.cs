namespace MessageMaster.Domain.Models.Core.Message
{
    public record class StringMessage(long Id, string Content) : MessageBase(Id) { }
}
