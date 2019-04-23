using Camera.Domain.Abstractions;
using System;
using System.Threading;

namespace Camera.Infrastructure
{
    public class DefaultDeviceStorage : IDeviceStorage
    {
        private ICameraDomain _cameraDomain;

        //register the device into operation system of PC 
        //with specified settings and identifier from domain object.
        public void Create(ICameraDomain camera)
        {
            //here is some logic to register/create physical device
            //emulate applying settings
            Thread.Sleep(10000);

            _cameraDomain = camera;
        }

        //apply some settings from domain object to physical device
        public void Update(ICameraDomain camera)
        {
            //here is some logic to apply settings to physical device
            //emulate applying settings
            Thread.Sleep(10000);

            _cameraDomain = camera;

        }

        public ICameraDomain GetByIdentifier(Guid id)
        {
            if (_cameraDomain.DeviceGuid == id)
            {
                return _cameraDomain;
            }

            throw new DeviceGuidNotFoundException(id);
        }
    }
}
