using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Models.Foundations.Guests.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheenam.Api.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        [Fact]
        public async Task ShoudThrowValidationExceptionOnAddGuestsIsNullAndLogItAsync()
        {
            // Given
            Guest nullGuest = null;
            var nullGuestException = new NullGuestException();
            var exceptedGuestValidationException = new GuestValidationException(nullGuestException);

            // when
            ValueTask<Guest> addGuestTask = this.guestService.AddGuestAsync(nullGuest);

            // then
            await Assert.ThrowsAsync<GuestValidationException>(() => addGuestTask.AsTask());
        }
    }
}
