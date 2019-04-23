using System;

namespace Camera.Domain.Abstractions
{
    public interface ICameraDomain
    {
        CameraState CameraState { get; }
        int ZoomScale { get; }
        SpeedMode SpeedMode { get; }
        int SpeedScale { get; }
        Point Coordinates { get; }
        Guid DeviceGuid { get; }

        void TurnOn();

        void TurnOff();

        void Zoom(int zoomScale);

        void SpeedUp(int scale);

        void Reset();

        void MoveTo(int x, int y, int z);
    }
}
