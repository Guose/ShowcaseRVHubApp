using ShowcaseRVHub.WebApi.Data.Repositories;

namespace ShowcaseRVHub.XUnitTest
{
    public class UserAPITests
    {
        private readonly UserRepo userAPIs = new UserRepo(
            ShowcaseDbContextHelper.GetMockDb(nameof(UserAPITests)));

        [Fact]
        public void Can_GetAll_Users()
        {
            var users = userAPIs.GetUsersAsync();
            Assert.NotNull(users);
        }

        [Fact]
        public void Can_Get_User_By_ID()
        {
            var user = userAPIs.GetUserByIdAsync(Guid.Parse("BD06B1F3-5381-48FE-A444-C1054F1E0BF6"));
            Assert.NotNull(user);
        }
    }
}