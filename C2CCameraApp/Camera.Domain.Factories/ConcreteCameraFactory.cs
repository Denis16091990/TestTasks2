using Camera.Domain.Abstractions;
using Domain.Impl;
using System;
namespace Camera.Domain.Factories
{
    public class ConcreteCameraFactory
    {
        public static ICameraDomain Create(CameraType type)
        {
            switch (type)
            {
                case CameraType.Fixed:
                    return new FixedCameraDomain();
                case CameraType.Quadcopter:
                    return new QuadcopterDomain();
            }

            throw new NotSupportedException();
        }

    }
}
