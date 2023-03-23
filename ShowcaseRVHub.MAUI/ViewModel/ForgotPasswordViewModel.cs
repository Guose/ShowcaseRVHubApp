using ShowcaseRVHub.MAUI.Model;
using ShowcaseRVHub.MAUI.Services.Interfaces;

namespace ShowcaseRVHub.MAUI.ViewModel
{
    public partial class ForgotPasswordViewModel : ViewModelBase
    {
        private readonly IShowcaseUserDataService _dataService;
        private readonly IUserService _userService;
        private UserModel _user;

        public ForgotPasswordViewModel(IUserService userService, IShowcaseUserDataService dataService)
        {
            _userService = userService;
            _dataService = dataService;
        }

        [ObservableProperty]
        string forgotPasswordEmail;

        [ObservableProperty]
        string passwordReset;

        [ObservableProperty]
        string confirmPasswordReset;

        [ObservableProperty]
        bool isPasswordResetSuccessful;

        public async Task ResetPasswordAsync(string newPassword)
        {
            List<UserModel> users = await _dataService.GetAllUsersAsync();
            IsPasswordResetSuccessful = await _userService.ResetPasswordAsync(ForgotPasswordEmail);

            if (IsPasswordResetSuccessful)
            {
                UserModel user = users.FirstOrDefault(u => u.Email == ForgotPasswordEmail);
                if(user != null)
                {
                    user.Password = newPassword;
                    await _dataService.UpdateUserAsync(user);
                }
            }
        }

        public async Task RetrieveUsernameAsync()
        {
            throw new NotImplementedException();
        }
    }
}
