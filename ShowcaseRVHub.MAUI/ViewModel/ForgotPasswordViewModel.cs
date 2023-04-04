using ShowcaseRVHub.MAUI.Model;
using ShowcaseRVHub.MAUI.Services.Interfaces;

namespace ShowcaseRVHub.MAUI.ViewModel
{
    public partial class ForgotPasswordViewModel : ViewModelBase
    {
        private readonly IShowcaseUserDataService _dataService;
        private readonly IUserEmailService _userService;
        private readonly IUserRepository _userRepository;

        public ForgotPasswordViewModel(
            IUserEmailService userService,
            IUserRepository userRepository,
            IShowcaseUserDataService dataService)
        {
            _userService = userService;
            _userRepository = userRepository;
            _dataService = dataService;
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

                string email = ForgotPasswordEmail == null ? string.Empty : ForgotPasswordEmail.ToLower();
                IsPasswordResetSuccessful = await _userService.ResetPasswordAsync(email);

                if (IsPasswordResetSuccessful)
                {
                    // Simulate sending a password reset email
                    // In a real implementation, you would send an email with a unique link for resetting the password                                       
                }
                else
                {
                    await Shell.Current.DisplayAlert("Something is wrong!", $"Failed to retrieve password... Please enter your email", "OK");
                    Debug.WriteLine("---> FAILED TO RETRIEVE PASSWORD { IsPasswordResetSuccessful is false }");
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

                string email = ForgotUsernameEmail == null ? string.Empty : ForgotUsernameEmail.ToLower();
                IsPasswordResetSuccessful = await _userService.RetrieveUsernameAsync(email);

                if (IsPasswordResetSuccessful)
                {
                    UserModel user = await _userRepository.GetUserByEmailAsync(email);
                    if (user != null)
                    {
                        await Shell.Current.DisplayAlert("Forgot Username?", $"Username: \"{user.Username}\" - retrieved for {email}", "OK");
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Something is wrong!", $"Failed to retrieve username for {email}", "OK");
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
