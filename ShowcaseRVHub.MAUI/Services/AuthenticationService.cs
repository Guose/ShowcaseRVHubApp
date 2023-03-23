using ShowcaseRVHub.MAUI.Model;
using ShowcaseRVHub.MAUI.Services.Interfaces;

namespace ShowcaseRVHub.MAUI.Services
{
    public class AuthenticationService
    {
        private readonly UserModel _userModel;

        public AuthenticationService(UserModel userModel)
        {
            _userModel = userModel;
        }
        public async Task<bool> Authenticate(string username, string password)
        {
            // Return true if the user is authenticated, false otherwise
            return await Task.Run(() => username == _userModel.Username && password == _userModel.Password);
        }
    }
}
