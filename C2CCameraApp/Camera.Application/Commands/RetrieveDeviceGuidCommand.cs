using System;
using System.Collections.Generic;
using System.Text;
using СommunicationChannel.Abstraction;

namespace Camera.Application.Commands
{
    public class RetrieveDeviceGuidCommand : ICommand
    {
        public Guid DeviceGuid { get; private set; }

        public RetrieveDeviceGuidCommand(Guid deviceId)
        {
            DeviceGuid = deviceId;
        }
    }
}
