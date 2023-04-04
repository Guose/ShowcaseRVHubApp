using ShowcaseRVHub.MAUI.Services;

namespace ShowcaseRVHub.XUnit
{
    public class FunctionalTests
    {
        [Fact]
        public void ShowcaseMauiUpdateApiTest()
         {
            ShowcaseUserDataService dataService = new ShowcaseUserDataService();

            Assert.NotNull(dataService);
        }
    }
}