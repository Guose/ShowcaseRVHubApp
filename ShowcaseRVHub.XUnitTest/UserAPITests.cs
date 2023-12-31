using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.XUnitTest
{
    public class UserAPITests
    {
        private readonly UserRepo userAPIs = new(
            ShowcaseDbContextHelper.GetMockDb(nameof(UserAPITests)));

        private readonly Guid _userId = new("CF3E94B7-4052-4585-86E8-B4EA68BA1BDF");
        public ShowcaseUserDto? User { get; set; }

        [Fact]
        public async Task Can_Get_All_Users()
        {
            IEnumerable<ShowcaseUserDto>? users = await userAPIs.GetAllUsersAsync();
            Assert.NotNull(users);
        }

        [Fact]
        public async Task Can_Get_User_By_ID()
        {
            User = await userAPIs.GetUserByIdAsync(_userId);
            Assert.NotNull(User);
        }

        [Fact]
        public async Task Can_Get_User_By_ID_FAIL_Firstname()
        {
            User = await userAPIs.GetUserByIdAsync(_userId);
            Assert.NotEqual("Johnson", User?.FirstName);
        }

        [Fact]
        public async Task Can_Delete_User_By_ID()
        {
            User = await userAPIs.GetUserByIdAsync(_userId);

            if (User == null)
                Assert.Fail();

            // TODO: Add generic repository "Remove()" method
            // Assert.True(await userAPIs.DeleteUserAsync(User.Id));
        }

        [Fact]
        public async Task Can_Get_All_User_Vehicles_2()
        {
            User = await userAPIs.GetUserByIdAsync(_userId);
            Assert.True(User?.Vehicles?.Count == 2);
        }
    }
}