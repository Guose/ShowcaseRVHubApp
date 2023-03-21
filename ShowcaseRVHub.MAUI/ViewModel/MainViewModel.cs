using ShowcaseRVHub.MAUI.Model;
using ShowcaseRVHub.MAUI.View;

namespace ShowcaseRVHub.MAUI.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        private UserModel _user;

        public MainViewModel()
        {
            _user = new UserModel
            {
                Id = Guid.NewGuid(),
                Email = "justin@showcasemi.com",
                FirstName = "Justin",
                LastName = "Elder",
                Phone = "(425)923-4362",
                Username = "Justin",
                Password = "Justin",
                IsRemembered = true,
            };
        }

        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;

        private bool isRemembered;
        public bool IsRemembered
        {
            get => isRemembered;
            set => SetProperty(ref isRemembered, value);
        }

        [RelayCommand]
        public async Task<bool> ValidateUser()
        {
            // Check the username and password against a database or other source of truth

            // Authenticate the user with the entered credentials
            bool isAuthenticated = await AuthenticationService.Authenticate(Username, Password);

            if (isAuthenticated && IsValid(_user.Username, _user.Password))
            {
                // Save the user's credentials if they opted to remember them
                if (IsRemembered)
                {
                    _user.IsRemembered = IsRemembered;

                    _ = SecureStorage.SetAsync("username", Username);
                    _ = SecureStorage.SetAsync("password", Password);
                }

                // Navigate to the main page
                await Shell.Current.GoToAsync(nameof(RVNavigationView), true, new Dictionary<string, object>
                {
                    {"User", _user }
                });
            }
            else
            {
                // Display an error message
                await Shell.Current.DisplayAlert("Login Failed", "Invalid username or password", "OK");
            }

            return isAuthenticated;
        }

        private bool IsValid(string username, string password) => username == Username && password == Password;
        // TODO: Implement this method to check the username and password against a database or other source of truth
    }
}
