using Camera.Application.Commands;
using System;
using СommunicationChannel.Abstraction;

namespace ClientApplication
{
    public class RetrieveDeviceGuidCommandHandler : ICommandHandler<RetrieveDeviceGuidCommand>
    {
        public Guid Result { get; private set; }
        public void Handle(RetrieveDeviceGuidCommand @event)
        {
            Result = @event.DeviceGuid;
        }
    }
}
