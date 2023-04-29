using LinqToDB;
using ShowcaseRVHub.MAUI.Model;
using ShowcaseRVHub.MAUI.Services.Interfaces;

namespace ShowcaseRVHub.MAUI.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly IShowcaseUserDataService _showcaseUserDataService;
        private List<UserModel> _users;

        public UserRepository(IShowcaseUserDataService showcaseUserDataService)
        {
            _showcaseUserDataService = showcaseUserDataService;
        }
        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            _users = await _showcaseUserDataService.GetAllUsersAsync();

            UserModel user = new UserModel();
            user = _users.Where(u => u.Email == email).FirstOrDefault();

            return await Task.FromResult(user);
        }
    }
}
