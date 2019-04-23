using System;

namespace Camera.Domain.Abstractions
{
    public interface IDeviceStorage
    {
        void Create(ICameraDomain camera);
        void Update(ICameraDomain camera);
        ICameraDomain GetByIdentifier(Guid id);
    }
}
