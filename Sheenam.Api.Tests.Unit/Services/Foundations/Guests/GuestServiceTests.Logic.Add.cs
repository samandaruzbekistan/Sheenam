using FluentAssertions;
using Moq;
using Sheenam.Api.Models.Foundations.Guests;

namespace Sheenam.Api.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
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

            storageBrokerMock.Setup(broker => broker.InsertGuestAsync(randomGuest)).ReturnsAsync(randomGuest);

            // Act
            Guest actual = await guestService.AddGuestAsync(randomGuest);

            // Assert
            actual.Should().BeEquivalentTo(randomGuest);
        }
    }
}
