using System;
using System.Collections.Generic;
using System.Text;

namespace Camera.Infrastructure
{
    public class DeviceGuidNotFoundException : Exception
    {
        public DeviceGuidNotFoundException(Guid id) : this($"The device with guid {id.ToString()} not found.")
        { }

        public DeviceGuidNotFoundException(string message)
            : base(message)
        { }

        public DeviceGuidNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
