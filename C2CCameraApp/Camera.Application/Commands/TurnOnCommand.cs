using System;
using СommunicationChannel.Abstraction;

namespace Camera.Application
{
    public class TurnedOnCommand : ICommand
    {
        public Guid DeviceGuid { get; private set; }

        public TurnedOnCommand(Guid deviceId)
        {
            DeviceGuid = deviceId;
        }
    }
}
