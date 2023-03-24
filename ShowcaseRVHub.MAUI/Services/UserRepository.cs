using LinqToDB;
using ShowcaseRVHub.MAUI.Model;
using ShowcaseRVHub.MAUI.Services.Interfaces;

namespace ShowcaseRVHub.MAUI.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly IShowcaseUserDataService _showcaseUserDataService;
        private IQueryable<UserModel> _users;

        public UserRepository(IShowcaseUserDataService showcaseUserDataService)
        {
            _showcaseUserDataService = showcaseUserDataService;
        }
        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            _users = await _showcaseUserDataService.GetAllUsersAsync();

            return await Task.FromResult(await _users.Where(e => e.Email == email).FirstOrDefaultAsync());
        }
    }
}
