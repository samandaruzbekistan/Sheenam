using Moq;
using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Services.Foundations.Guests;


namespace Sheenam.Api.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly IGuestService guestService;

        public GuestServiceTests()
        {
            storageBrokerMock = new Mock<IStorageBroker>();
            guestService = new GuestService(storageBroker: storageBrokerMock.Object);
        }
    }
}
