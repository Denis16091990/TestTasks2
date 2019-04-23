using System;

namespace СommunicationChannel.Abstraction
{
    public interface ICommunicationChannel
    {
        void Subcribe<T>(ICommandHandler<T> handler)
            where T : ICommand;

        void Unsubscribe<T>()
            where T : ICommand;

        void Publish<T>(T @event)
             where T : ICommand;
    }
}
