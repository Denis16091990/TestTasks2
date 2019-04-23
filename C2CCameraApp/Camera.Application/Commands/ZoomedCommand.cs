using System;
using СommunicationChannel.Abstraction;

namespace Camera.Application
{
    public class ZoomedCommand : ICommand
    {
        public int ZoomScale { get; }

        public Guid DeviceGuid { get; private set; }

        public ZoomedCommand(Guid deviceGuid, int zoomScale)
        {
            DeviceGuid = deviceGuid;
            ZoomScale = zoomScale;
        }
    }
}
