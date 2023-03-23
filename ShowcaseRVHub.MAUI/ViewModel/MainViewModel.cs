using ShowcaseRVHub.MAUI.Model;
using ShowcaseRVHub.MAUI.Services.Interfaces;
using ShowcaseRVHub.MAUI.View;

namespace ShowcaseRVHub.MAUI.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        IShowcaseUserDataService _dataService;
        List<UserModel> _users;
        UserModel _user;

        public MainViewModel(IShowcaseUserDataService dataService)
        {
            _dataService = dataService;
            _user = new UserModel();
            LoadUsersFromDatabase();
        }        

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotRemembered))]
        bool isRemembered;

        public bool IsNotRemembered => !IsRemembered;

        private async void LoadUsersFromDatabase()
        {
            _users = await _dataService.GetAllUsersAsync();
            if (_users == null || _users.Count <= 0)
            {
                Debug.WriteLine("---> Database connection failed.");
                await Shell.Current.DisplayAlert("Something went wrong!", $"Make sure service is running to the database...", "OK");
                return;
            }
        }        

        [RelayCommand]
        public async Task ValidateUser()
        {
            if (IsBusy)
                return;

            try
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert(
                        "No connectivity!", $"Please check internet and try again.", "OK");
                    return;
                }

                IsBusy = true;

                // Perform authentication logic here (e.g., call an API endpoint, check against a database)
                _user = _users.FirstOrDefault(u => u.Username == Username && u.Password == Password);                          

                // Authenticate the user with the entered credentials
                AuthenticationService auth = new AuthenticationService(_user);
                if (await auth.Authenticate(Username, Password) || _user == null)
                {
                    // Save the user's credentials if they opted to remember them
                    if (!_user.IsRemembered && IsRemembered || _user.IsRemembered && IsNotRemembered)
                    {
                        _user.IsRemembered = IsRemembered;
                        await _dataService.UpdateUserAsync(_user);
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to validate user: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally 
            { 
                IsBusy = false; 

                if (IsNotRemembered)
                {
                    Password = string.Empty;
                    Username = string.Empty;
                }
            }
        }
    }
}
