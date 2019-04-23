using Camera.Domain.Abstractions;
using System;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Domain.Impl.UnitTests")]
[assembly: InternalsVisibleTo("Domain.Factories")]
namespace Domain.Impl
{
    internal class QuadcopterDomain : ICameraDomain
    {
        public CameraState CameraState => _fixedCamera.CameraState;

        public int ZoomScale => _fixedCamera.ZoomScale;

        public SpeedMode SpeedMode => _fixedCamera.SpeedMode;

        public int SpeedScale => _fixedCamera.SpeedScale;

        public Point Coordinates { get; private set; }

        public Guid DeviceGuid => _fixedCamera.DeviceGuid;

        private readonly ICameraDomain _fixedCamera;

        internal QuadcopterDomain(
            SpeedMode speedMode = SpeedMode.Normal,
            int zoomScale = 1,
            int speedScale = 1,
            int x = 0,
            int y = 0,
            int z = 0
            )
        {
            _fixedCamera = new FixedCameraDomain(speedMode, zoomScale, speedScale);
            Coordinates = new Point(x, y, z);
        }

        public void MoveTo(int x, int y, int z)
        {
            if (_fixedCamera.CameraState == CameraState.TurnedOn)
            {
                Coordinates = new Point(x, y, z);
            }
            else
            {
                throw new CameraDomainException("The camera is turned off");
            }
        }

        public void Reset()
        {
            _fixedCamera.Reset();
            Coordinates = new Point(0, 0, 0);
        }

        public void SpeedUp(int scale)
        {
            _fixedCamera.SpeedUp(scale);
        }

        public void TurnOff()
        {
            _fixedCamera.TurnOff();
        }

        public void TurnOn()
        {
            _fixedCamera.TurnOn();
        }

        public void Zoom(int zoomScale)
        {
            _fixedCamera.Zoom(zoomScale);
        }
    }
}
