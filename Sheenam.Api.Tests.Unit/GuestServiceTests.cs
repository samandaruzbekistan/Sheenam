using FluentAssertions;
using Moq;
using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Services.Foundations.Guests;


namespace Sheenam.Api.Tests.Unit
{
    public class GuestServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly IGuestService guestService;

        public GuestServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.guestService = new GuestService(storageBroker: this.storageBrokerMock.Object);
        }

        [Fact]
        public async Task ShouldAddGuestAsync()
        {
            // Arrange
            Guest randomGuest = new Guest
            {
                Id = Guid.NewGuid(),
                FirstName = "Samandar",
                LastName = "Sariboyev",
                Address = "Gulistan, Sirdarya, Uzbekistan",
                DateOfBirth = DateTimeOffset.Now,
                Email = "samandar@gmail.com",
                Gender = GenderType.Male,
                PhoneNumber = "+998975672009"
            };

            this.storageBrokerMock.Setup(broker => broker.InsertGuestAsync(randomGuest)).ReturnsAsync(randomGuest);

            // Act
            Guest actual = await this.guestService.AddGuestAsync(randomGuest);

            // Assert
            actual.Should().BeEquivalentTo(randomGuest);
        }
    }
}
