using Camera.Domain.Abstractions;
using Domain.Impl;
using Xunit;

namespace BaseCamera.Domain.UnitTests
{
    public class FixedCameraTests
    {
        private const CameraState TurnedOnDeviceState = CameraState.TurnedOn;
        private const CameraState TurnedOffDeviceState = CameraState.TurnedOff;

        private const string TurnedOffExceptionMessage = "The camera is turned off";
        private const string IncorrectZoomValueMessage = "Scale param can't be less or equal than 0.";

        private const int ScaleDefaultValue = 1;
        private const int ZoomBy10 = 10;
        private const int IncorrentZoomValue = -2;
        private const int SpeedUpScaleValue = 100;
        private const int SlowDownScaleValue = -100;
        private const int ZeroSpeedUpValue = 0;

        [Fact]
        public void SpeedUp_IfCameraIsTurnedOffOrPending_ThrowFailException()
        {
            //set up
            var camera = new FixedCameraDomain();

            //act
            var ex = Record.Exception(() => camera.SpeedUp(SpeedUpScaleValue));

            //asserts
            Assert.NotNull(ex);
            Assert.IsType<CameraDomainException>(ex);
            Assert.Equal(TurnedOffExceptionMessage, ex.Message);

            Assert.Equal(ScaleDefaultValue, camera.ZoomScale);
            Assert.Equal(SpeedMode.Normal, camera.SpeedMode);
            Assert.Equal(ScaleDefaultValue, camera.SpeedScale);
            Assert.NotEqual(TurnedOnDeviceState, camera.CameraState);
        }

        [Fact]
        public void SpeedUp_IfCameraIsTurnedOnAndSpeedUpValueIsZero_ApplySpeedUpDefaultSettings()
        {
            //set up
            var camera = new FixedCameraDomain();
            camera.TurnOn();

            //act
            camera.SpeedUp(ZeroSpeedUpValue);

            //asserts
            Assert.Equal(ScaleDefaultValue, camera.ZoomScale);
            Assert.Equal(SpeedMode.Normal, camera.SpeedMode);
            Assert.Equal(ScaleDefaultValue, camera.SpeedScale);
            Assert.Equal(TurnedOnDeviceState, camera.CameraState);
        }

        [Fact]
        public void SpeedUp_IfCameraIsTurnedOnAndSpeedUpValueIsPositive_ApplySpeedUpSettings()
        {
            //set up
            var camera = new FixedCameraDomain();
            camera.TurnOn();

            //act
            camera.SpeedUp(SpeedUpScaleValue);

            //asserts
            Assert.Equal(ScaleDefaultValue, camera.ZoomScale);
            Assert.Equal(SpeedMode.SpeedUp, camera.SpeedMode);
            Assert.Equal(SpeedUpScaleValue, camera.SpeedScale);
            Assert.Equal(TurnedOnDeviceState, camera.CameraState);
        }

        [Fact]
        public void SpeedUp_IfCameraIsTurnedOnAndSpeedValueIsNegative_ApplySlowDownSettings()
        {
            //set up
            var camera = new FixedCameraDomain();
            camera.TurnOn();

            //act
            camera.SpeedUp(SlowDownScaleValue);

            //asserts
            Assert.Equal(ScaleDefaultValue, camera.ZoomScale);
            Assert.Equal(SpeedMode.SlowDown, camera.SpeedMode);
            Assert.Equal(SlowDownScaleValue, camera.SpeedScale);
            Assert.Equal(TurnedOnDeviceState, camera.CameraState);
        }

        [Fact]
        public void Reset_IfCameraIsTurnedOn_ApplyDefaultSettings()
        {
            //set up
            var camera = new FixedCameraDomain();
            camera.TurnOn();
            camera.SpeedUp(SpeedUpScaleValue);
            camera.Zoom(ZoomBy10);

            //act
            camera.Reset();

            //asserts
            Assert.Equal(ScaleDefaultValue, camera.ZoomScale);
            Assert.Equal(SpeedMode.Normal, camera.SpeedMode);
            Assert.Equal(ScaleDefaultValue, camera.SpeedScale);
            Assert.Equal(TurnedOnDeviceState, camera.CameraState);
        }

        [Fact]
        public void Reset_IfCameraIsTurnedOff_ThrowFailException()
        {
            //set up
            var camera = new FixedCameraDomain();

            //act
            var ex = Record.Exception(() => camera.Reset());

            //asserts
            Assert.NotNull(ex);
            Assert.IsType<CameraDomainException>(ex);
            Assert.Equal(TurnedOffExceptionMessage, ex.Message);

            Assert.Equal(ScaleDefaultValue, camera.ZoomScale);
            Assert.Equal(SpeedMode.Normal, camera.SpeedMode);
            Assert.Equal(ScaleDefaultValue, camera.SpeedScale);
            Assert.NotEqual(TurnedOnDeviceState, camera.CameraState);
        }

        [Fact]
        public void Zoom_IfCameraIsTurnedOn_ApplyZoomSettings()
        {
            //set up
            var camera = new FixedCameraDomain();
            camera.TurnOn();

            //act
            camera.Zoom(ZoomBy10);

            //asserts
            Assert.Equal(ZoomBy10, camera.ZoomScale);
            Assert.Equal(SpeedMode.Normal, camera.SpeedMode);
            Assert.Equal(ScaleDefaultValue, camera.SpeedScale);
            Assert.Equal(TurnedOnDeviceState, camera.CameraState);
        }

        [Fact]
        public void Zoom_IfCameraIsTurnedOnAndZoomValueIsIncorrect_ThrowFailException()
        {
            //set up
            var camera = new FixedCameraDomain();
            camera.TurnOn();

            //act
            var ex = Record.Exception(() => camera.Zoom(IncorrentZoomValue));

            //asserts
            Assert.NotNull(ex);
            Assert.IsType<CameraDomainException>(ex);
            Assert.Equal(IncorrectZoomValueMessage, ex.Message);

            Assert.Equal(ScaleDefaultValue, camera.ZoomScale);
            Assert.Equal(SpeedMode.Normal, camera.SpeedMode);
            Assert.Equal(ScaleDefaultValue, camera.SpeedScale);
            Assert.Equal(TurnedOnDeviceState, camera.CameraState);
        }

        [Fact]
        public void Zoom_IfCameraIsTurnedOff_ThrowFailException()
        {
            //set up
            var camera = new FixedCameraDomain();

            //act
            var ex = Record.Exception(() => camera.Zoom(ZoomBy10));

            //asserts
            Assert.NotNull(ex);
            Assert.IsType<CameraDomainException>(ex);
            Assert.Equal(TurnedOffExceptionMessage, ex.Message);

            Assert.Equal(ScaleDefaultValue, camera.ZoomScale);
            Assert.Equal(SpeedMode.Normal, camera.SpeedMode);
            Assert.Equal(ScaleDefaultValue, camera.SpeedScale);
            Assert.NotEqual(TurnedOnDeviceState, camera.CameraState);
        }
    }
}
