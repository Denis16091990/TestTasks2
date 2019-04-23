using Camera.Domain.Abstractions;
using Domain.Impl;
using Xunit;

namespace Quadcopter.Domain.UnitTests
{
    public class QuadcopterTests
    {
        private const CameraState TurnedOnDeviceState = CameraState.TurnedOn;
        private const CameraState TurnedOffDeviceState = CameraState.TurnedOff;

        private const string TurnedOffExceptionMessage = "The camera is turned off";
        private const string IncorrectZoomValueMessage = "Scale param can't be less or equal than 0.";

        private const int X = 100;
        private const int Y = 100;
        private const int Z = 100;

        private const int DefaultCoordinate = 0;

        private const int ScaleDefaultValue = 1;

        [Fact]
        public void MoveTo_IfCameraIsTurnedOn_ApplyCoordinates()
        {
            //set up
            var quadcopter = new QuadcopterDomain();
            quadcopter.TurnOn();

            //act
            quadcopter.MoveTo(X, Y, Z);

            //asserts
            Assert.Equal(ScaleDefaultValue, quadcopter.ZoomScale);
            Assert.Equal(SpeedMode.Normal, quadcopter.SpeedMode);
            Assert.Equal(ScaleDefaultValue, quadcopter.SpeedScale);
            Assert.Equal(TurnedOnDeviceState, quadcopter.CameraState);

            Assert.Equal(X, quadcopter.Coordinates.X);
            Assert.Equal(Y, quadcopter.Coordinates.Y);
            Assert.Equal(Z, quadcopter.Coordinates.Z);
        }

        [Fact]
        public void MoveTo_IfCameraIsTurnedOff_ThrowFailException()
        {
            //set up
            var quadcopter = new QuadcopterDomain();

            //act
            var ex = Record.Exception(() => quadcopter.MoveTo(X, Y, Z));

            //asserts
            Assert.NotNull(ex);
            Assert.IsType<CameraDomainException>(ex);
            Assert.Equal(TurnedOffExceptionMessage, ex.Message);

            Assert.Equal(ScaleDefaultValue, quadcopter.ZoomScale);
            Assert.Equal(SpeedMode.Normal, quadcopter.SpeedMode);
            Assert.Equal(ScaleDefaultValue, quadcopter.SpeedScale);
            Assert.NotEqual(TurnedOnDeviceState, quadcopter.CameraState);

            Assert.Equal(DefaultCoordinate, quadcopter.Coordinates.X);
            Assert.Equal(DefaultCoordinate, quadcopter.Coordinates.Y);
            Assert.Equal(DefaultCoordinate, quadcopter.Coordinates.Z);
        }
    }
}
