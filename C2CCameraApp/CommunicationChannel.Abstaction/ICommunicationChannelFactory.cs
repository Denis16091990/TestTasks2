namespace СommunicationChannel.Abstraction
{
    public interface ICommunicationChannelFactory
    {
        ICommunicationChannel Create(ChannelType type);
    }
}
