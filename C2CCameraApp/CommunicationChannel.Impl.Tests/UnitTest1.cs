using Camera.Application;
using Xunit;
using СommunicationChannel.Implementation;

namespace CommunicationChannel.Impl.Tests
{
    public partial class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var channel = new DefaultCommunicationChannel();
            var handler = new TurnOnCommandHandler();
            channel.Subcribe(handler);
            var @event = new TurnedOnCommand();
            channel.Publish(@event);


        }
    }
}
