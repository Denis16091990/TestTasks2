using Camera.Application.Commands;
using Camera.Domain.Abstractions;
using Camera.Domain.Factories;
using Camera.Infrastructure;
using СommunicationChannel.Abstraction;

namespace Camera.Application
{
    public class InitializationService
    {
        private static ICameraDomain _camera;
        private static IDeviceStorage _storage;

        static InitializationService()
        {
            _camera = ConcreteCameraFactory.Create(CameraType.Quadcopter);
            _storage = new DefaultDeviceStorage();
            _storage.Create(_camera);
        }

        public static void SetUpCommandHandlers(ICommunicationChannel channel)
        {
            var turnOnHandler = new TurnOnCommandHandler(_storage);
            var zoomHandler = new ZoomedCommandHandler(_storage);

            channel.Subcribe(turnOnHandler);
            channel.Subcribe(zoomHandler);
        }

        public static void SetUpCommandPublishers(ICommunicationChannel channel)
        {
            var retrieveDeviceGuidCommand = new RetrieveDeviceGuidCommand(_camera.DeviceGuid);
            channel.Publish(retrieveDeviceGuidCommand);
        }
    }
}
