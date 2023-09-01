namespace ShowcaseRVHub.MAUI.Helpers
{
    public class UserDataServiceHelper : IUserDataServiceHelper
    {
        private readonly IShowcaseUserDataService _showcaseUserDataService;
        private IEnumerable<UserModel> _users;

        public UserDataServiceHelper(IShowcaseUserDataService showcaseUserDataService)
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
