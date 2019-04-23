using Camera.Application;
using Microsoft.Extensions.DependencyInjection;
using СommunicationChannel.Abstraction;
using System;
using ClientApplication;
using CommunicationChannel.Factories;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ICommunicationChannelFactory, CommunicationChannelFactory>()
                .BuildServiceProvider();

            var channelFactory = serviceProvider.GetService<ICommunicationChannelFactory>();

            var channel = channelFactory.Create(ChannelType.InMemory);

            //camera application is subscribing on client command
            InitializationService.SetUpCommandHandlers(channel);

            //client app ia suscribing on device guid retrieving to futher communication with camera app
            var retrieveDeviceGuidHandler = new RetrieveDeviceGuidCommandHandler();
            channel.Subcribe(retrieveDeviceGuidHandler);

            //camera application is publishing device guid retrieving commnd
            InitializationService.SetUpCommandPublishers(channel);

            var deviceGuid = retrieveDeviceGuidHandler.Result;

            Console.WriteLine("Device guid is {0}", deviceGuid.ToString());
            try
            {

                Console.WriteLine("Turning the camera on...");

                TurnedOnCommand turnOnCommand = new TurnedOnCommand(deviceGuid);
                channel.Publish(turnOnCommand);

                Console.WriteLine("The camera has been turned on");


                Console.WriteLine("Zooming the camera...");

                ZoomedCommand zoomedCommand = new ZoomedCommand(deviceGuid, 10);
                channel.Publish(zoomedCommand);

                Console.WriteLine("The camera has been zoomed");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();

        }
    }
}
