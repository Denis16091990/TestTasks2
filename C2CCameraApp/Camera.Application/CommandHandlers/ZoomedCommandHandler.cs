using Camera.Domain.Abstractions;
using Camera.Infrastructure;
using System;
using System.Threading.Tasks;
using СommunicationChannel.Abstraction;

namespace Camera.Application
{
    public class ZoomedCommandHandler : ICommandHandler<ZoomedCommand>
    {
        private volatile IDeviceStorage _storage;

        public ZoomedCommandHandler(IDeviceStorage storage)
        {
            _storage = storage ?? throw new ArgumentException("storage");
        }

        public void Handle(ZoomedCommand @event)
        {
            try
            {
                var camera = _storage.GetByIdentifier(@event.DeviceGuid);
                camera.Zoom(@event.ZoomScale);
                _storage.Update(camera);
            }
            catch
            {
                throw;
            }
        }
    }
}
