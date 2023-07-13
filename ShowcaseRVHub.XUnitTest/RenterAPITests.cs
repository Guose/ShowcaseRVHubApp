using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.XUnitTest
{
    public class RenterAPITests
    {
        private readonly RenterRepo renterAPIs = new(
            ShowcaseDbContextHelper.GetMockDb(nameof(RenterAPITests)));

        [Fact]
        public async Task Can_GetAll_Renters()
        {
            IEnumerable<ShowcaseRenter>? renters = await renterAPIs.GetRentersAsync();
            Assert.NotNull(renters);
        }

        [Fact]
        public async Task Can_Get_Renter_By_ID()
        {
            ShowcaseRenter? renter = await renterAPIs.GetRenterByIdAsync(1);
            Assert.Equal("John", renter?.Firstname);
        }

        [Fact]
        public async Task Can_Get_Renter_By_ID_FAIL()
        {
            ShowcaseRenter? renter = await renterAPIs.GetRenterByIdAsync(2);
            Assert.NotEqual(1, renter?.Id);
        }

        [Fact]
        public async Task Can_Delete_Renter_By_ID()
        {
            ShowcaseRenter? renter = await renterAPIs.GetRenterByIdAsync(2);

            if (renter == null)
                Assert.Fail();
            else
                Assert.True(await renterAPIs.DeleteRenterAsync(renter.Id));
        }
    }
}
