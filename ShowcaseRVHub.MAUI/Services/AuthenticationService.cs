namespace ShowcaseRVHub.MAUI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserModel _userModel;

        public AuthenticationService(UserModel userModel)
        {
            _userModel = userModel;
        }
        public async Task<bool> Authenticate(string username, string password)
        {
            // Return true if the user is authenticated, false otherwise
            if (_userModel == null)
                return false;

            return await Task.Run(() => username == _userModel.Username && password == _userModel.Password);
        }
    }
}
