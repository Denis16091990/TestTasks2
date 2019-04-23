using System;
using СommunicationChannel.Abstraction;
using СommunicationChannel.Implementation;

namespace CommunicationChannel.Factories
{
    public class CommunicationChannelFactory : ICommunicationChannelFactory
    {
        public ICommunicationChannel Create(ChannelType type)
        {
            if (type == ChannelType.InMemory)
            {
                return new DefaultCommunicationChannel();
            }

            throw new NotImplementedException();
        }
    }
}
