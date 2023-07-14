using ShowcaseRVHub.WebApi.Models;
using System.Text.Json;

namespace ShowcaseRVHub.XUnitTest
{
    public class RentalAPITests
    {
        private readonly RentalRepo rentalAPIs = new(
            ShowcaseDbContextHelper.GetMockDb(nameof(RentalAPITests)));

        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RentalAPITests()
        {
            _httpClient = new HttpClient();
            _baseAddress = "http://192.168.1.10:5012";
            _url = $"{_baseAddress}/api/rentals/";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        [Fact]
        public async Task Can_GetAll_Rentals()
        {
            IEnumerable<Rental>? rentals = await rentalAPIs.GetRentalsAsync();
            Assert.NotNull(rentals);
        }

        [Fact]
        public async Task Can_Get_Rental_By_ID()
        {
            Rental? rental = await rentalAPIs.GetRentalByIdAsync(-1);
            Assert.NotNull(rental);
        }

        [Fact]
        public async Task Can_Get_Rental_By_ID_FAIL()
        {
            Rental? rental = await rentalAPIs.GetRentalByIdAsync(1);
            Assert.Null(rental);
        }

        [Fact]
        public async Task Can_Delete_Rental_By_ID()
        {
            Rental? rental = await rentalAPIs.GetRentalByIdAsync(-1);

            if (rental == null)
                Assert.Fail();

            Assert.True(await rentalAPIs.DeleteRentalAsync(rental.Id));
        }
    }
}
