using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.XUnitTest
{
    public class RentalAPITests
    {
        private readonly RentalRepo rentalAPIs = new(
            ShowcaseDbContextHelper.GetMockDb(nameof(RentalAPITests)));

        [Fact]
        public async Task Can_GetAll_Rentals()
        {
            IEnumerable<Rental>? rentals = await rentalAPIs.GetRentalsAsync();
            Assert.NotNull(rentals);
        }

        [Fact]
        public async Task Can_Get_Rental_By_ID()
        {
            Rental? rental = await rentalAPIs.GetRentalByIdAsync(1);
            Assert.NotNull(rental);
        }

        [Fact]
        public async Task Can_Get_Rental_By_ID_FAIL()
        {
            Rental? rental = await rentalAPIs.GetRentalByIdAsync(1);
            Assert.NotEqual(false, rental?.IsInteriorCleaned);
        }

        [Fact]
        public async Task Can_Delete_Rental_By_ID()
        {
            Rental? rental = await rentalAPIs.GetRentalByIdAsync(1);

            if (rental == null)
                Assert.Fail();

            Assert.True(await rentalAPIs.DeleteRentalAsync(rental.Id));
        }
    }
}
