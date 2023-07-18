using ShowcaseRVHub.MAUI.Helpers;

namespace ShowcaseRVHub.MAUI.ViewModel
{
    public partial class ForgotPasswordViewModel : ViewModelBase
    {
        private readonly IUserEmailService _userEmailService;
        private readonly IUserDataServiceHelper _userServiceHelper;

        public ForgotPasswordViewModel(IUserEmailService userEmailService, IUserDataServiceHelper userServiceHelper)
        {
            _userEmailService = userEmailService;
            _userServiceHelper = userServiceHelper;
        }

        [ObservableProperty]
        string forgotPasswordEmail;

        [ObservableProperty]
        string forgotUsernameEmail;

        [ObservableProperty]
        bool isPasswordResetSuccessful;

        [RelayCommand]
        public async Task RetrievePasswordAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!",
                        $"Please check internet and try again.", "OK");
                    return;
                }

                string emailPassword = !string.IsNullOrEmpty(ForgotPasswordEmail) ? ForgotPasswordEmail.ToLower() : string.Empty;

                IsPasswordResetSuccessful = await _userEmailService.ResetPasswordAsync(emailPassword);

                if (IsPasswordResetSuccessful)
                {
                    await Shell.Current.DisplayAlert("Message Sent!", $"Password Reset email has been sent to {emailPassword}", "OK");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Something is wrong!", $"Failed to retrieve password... Please enter your email", "OK");
                    Debug.WriteLine("---> FAILED TO RETRIEVE PASSWORD { IsPasswordResetSuccessful is false }");
                    return;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to validate user: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally { IsBusy = false; }
            
        }

        [RelayCommand]
        public async Task RetrieveUsernameAsync(string newUsername)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!",
                        $"Please check internet and try again.", "OK");
                    return;
                }

                string emailUsername = !string.IsNullOrEmpty(ForgotUsernameEmail) ? ForgotUsernameEmail.ToLower() : string.Empty;
                IsPasswordResetSuccessful = await _userEmailService.RetrieveUsernameAsync(emailUsername);

                if (IsPasswordResetSuccessful)
                {
                    UserModel user = await _userServiceHelper.GetUserByEmailAsync(emailUsername);
                    if (user != null)
                    {
                        await Shell.Current.DisplayAlert("Forgot Username?", $"Username: \"{user.Username}\" - retrieved for {emailUsername}", "OK");
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Something is wrong!", $"Failed to retrieve username for {emailUsername}", "OK");
                        Debug.WriteLine("---> FAILED TO RETRIEVE USERNAME { User is null }");
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Something is wrong!", $"Failed to retrieve username... Please enter your email", "OK");
                    Debug.WriteLine("---> FAILED TO RETRIEVE USERNAME { IsPasswordResetSuccessful is false }");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to validate user: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally { IsBusy = false; }

        }
    }
}
