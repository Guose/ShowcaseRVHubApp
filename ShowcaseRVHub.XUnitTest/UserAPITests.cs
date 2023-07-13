using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.XUnitTest
{
    public class UserAPITests
    {
        private readonly UserRepo userAPIs = new(
            ShowcaseDbContextHelper.GetMockDb(nameof(UserAPITests)));

        [Fact]
        public async Task Can_GetAll_Users()
        {
            IEnumerable<ShowcaseUser>? users = await userAPIs.GetUsersAsync();
            Assert.NotNull(users);
        }

        [Fact]
        public async Task Can_Get_User_By_ID()
        {
            ShowcaseUser? user = await userAPIs.GetUserByIdAsync(Guid.Parse("BD06B1F3-5381-48FE-A444-C1054F1E0BF6"));
            Assert.NotNull(user);
        }

        [Fact]
        public async Task Can_Get_User_By_ID_FAIL_Firstname()
        {
            ShowcaseUser? user = await userAPIs.GetUserByIdAsync(Guid.Parse("BD06B1F3-5381-48FE-A444-C1054F1E0BF6"));
            Assert.NotEqual("Johnson", user?.FirstName);
        }

        [Fact]
        public async Task Can_Delete_User_By_ID()
        {
            ShowcaseUser? user = await userAPIs.GetUserByIdAsync(Guid.Parse("BD06B1F3-5381-48FE-A444-C1054F1E0BF6"));

            if (user == null)
                Assert.Fail();

            Assert.True(await userAPIs.DeleteUserAsync(user.Id));
        }

        //[Fact]
        //public async Task Can_GetAll_User_Vehicles()
        //{
            
        //}
    }
}