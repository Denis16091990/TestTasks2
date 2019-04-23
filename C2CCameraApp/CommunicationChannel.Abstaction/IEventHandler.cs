using System;
using System.Threading.Tasks;

namespace СommunicationChannel.Abstraction
{
    public interface ICommandHandler<T> : ICommandHandler where T : ICommand
    {
        void Handle(T @event);
    }

    public interface ICommandHandler
    {
       // Guid DeviceGuid { get; }
    }
}