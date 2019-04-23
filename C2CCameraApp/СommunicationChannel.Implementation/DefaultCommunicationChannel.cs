using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using СommunicationChannel.Abstraction;
[assembly: InternalsVisibleTo("CommunicationChannel.Factories")]
namespace СommunicationChannel.Implementation
{
    internal class DefaultCommunicationChannel : ICommunicationChannel
    {
        private Dictionary<Type, ICommandHandler> _eventHandlerPairs = new Dictionary<Type, ICommandHandler>();

        public void Publish<T>(T @event)
            where T : ICommand
        {
            try
            {
                var @eventType = @event.GetType();

                var handler = _eventHandlerPairs[eventType];
         
                var eventHandler = (ICommandHandler<T>)handler;

                eventHandler.Handle(@event);
            }
            catch (KeyNotFoundException e)
            {
                throw new CommandHandlerNotFoundException("Handler was not found.", e);
            }
            catch
            {
                throw;
            }

        }

        public void Subcribe<T>(ICommandHandler<T> handler)
            where T : ICommand
        {
            var @event = typeof(T);

            _eventHandlerPairs.Add(@event, handler);
        }

        public void Unsubscribe<T>()
            where T : ICommand
        {
            var @event = typeof(T);

            _eventHandlerPairs.Remove(@event);
        }
    }

}
