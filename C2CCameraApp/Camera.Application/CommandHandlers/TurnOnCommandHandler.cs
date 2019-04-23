using Camera.Domain.Abstractions;
using System;
using СommunicationChannel.Abstraction;

namespace Camera.Application
{
    public class TurnOnCommandHandler : ICommandHandler<TurnedOnCommand>
    {
        private volatile IDeviceStorage _storage;

        public TurnOnCommandHandler(IDeviceStorage storage)
        {
            _storage = storage ?? throw new ArgumentException("storage");
        }

        public void Handle(TurnedOnCommand @event)
        {
            try
            {
                var camera = _storage.GetByIdentifier(@event.DeviceGuid);
                camera.TurnOn();
                _storage.Update(camera);
            }
            catch
            {
                throw;
            }
            return;
        }
    }
}
