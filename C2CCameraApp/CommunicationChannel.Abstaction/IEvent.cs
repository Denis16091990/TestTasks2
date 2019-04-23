using System;

namespace СommunicationChannel.Abstraction
{
    public interface ICommand
    {
        Guid DeviceGuid { get; }
    }
}