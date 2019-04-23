using Camera.Domain.Abstractions;
using System;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Domain.Impl.UnitTests")]
[assembly: InternalsVisibleTo("Domain.Factories")]
namespace Domain.Impl
{
    class FixedCameraDomain : ICameraDomain
    {
        public CameraState CameraState { get; private set; }
        public int ZoomScale { get; private set; }
        public SpeedMode SpeedMode { get; private set; }
        public int SpeedScale { get; private set; }

        public Point Coordinates =>
            throw new NotSupportedException("The operation does not support for the camera device.");

        public Guid DeviceGuid { get; private set; }

        private const int ScaleDefaultValue = 1;

        internal FixedCameraDomain(
            SpeedMode speedMode = SpeedMode.Normal,
            int zoomScale = 1,
            int speedScale = 1
            )
        {
            if (zoomScale <= 0)
            {
                throw new CameraDomainException("Zoom scale param can't be less or equal than 0.");
            }

            DeviceGuid = Guid.NewGuid();
            CameraState = CameraState.Pending;
            ZoomScale = zoomScale;
            SpeedScale = speedScale == 0 ? ScaleDefaultValue : speedScale;
            SpeedMode = SpeedMode.Normal;
        }

        public void TurnOn()
        {
            if (CameraState == CameraState.TurnedOn)
            {
                return;
            }

            CameraState = CameraState.TurnedOn;
        }

        public void TurnOff()
        {
            if (CameraState == CameraState.TurnedOff)
            {
                return;
            }

            CameraState = CameraState.TurnedOff;
        }

        public void Zoom(int zoomScale)
        {
            if (zoomScale <= 0)
            {
                throw new CameraDomainException("Scale param can't be less or equal than 0.");
            }
            if (CameraState != CameraState.TurnedOn)
            {
                throw new CameraDomainException("The camera is turned off");
            }

            ZoomScale = zoomScale;
        }

        public void SpeedUp(int scale)
        {
            if (CameraState != CameraState.TurnedOn)
            {
                throw new CameraDomainException("The camera is turned off");
            }

            if (scale == 0)
            {
                SpeedMode = SpeedMode.Normal;
                SpeedScale = ScaleDefaultValue;
                return;
            }
            if (scale > 0)
            {
                SpeedMode = SpeedMode.SpeedUp;
            }
            if (scale < 0)
            {
                SpeedMode = SpeedMode.SlowDown;
            }

            SpeedScale = scale;
        }

        public void Reset()
        {
            if (CameraState != CameraState.TurnedOn)
            {
                throw new CameraDomainException("The camera is turned off");
            }

            ZoomScale = ScaleDefaultValue;
            SpeedScale = ScaleDefaultValue;
            SpeedMode = SpeedMode.Normal;
        }

        public void MoveTo(int x, int y, int z)
        {
            throw new NotSupportedException("The operation does not support for the camera device.");
        }
    }
}
