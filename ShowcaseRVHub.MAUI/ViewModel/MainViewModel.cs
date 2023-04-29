namespace ShowcaseRVHub.MAUI.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        readonly IShowcaseUserDataService _dataService;
        UserModel _user;

        public MainViewModel(IShowcaseUserDataService dataService)
        {
            _dataService = dataService;
            _user = new UserModel();
        }

        List<UserModel> Users { get; set; }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotRemembered))]
        bool isRemembered;

        public bool IsNotRemembered => !IsRemembered;       

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

                Users = await _dataService.GetAllUsersAsync();

                // Perform authentication logic here (e.g., call an API endpoint, check against a database)
                _user = Users.Where(u => u.Username == Username && u.Password == Password).FirstOrDefault();                         

                // Authenticate the user with the entered credentials
                AuthenticationService auth = new AuthenticationService(_user);
                if (await auth.Authenticate(Username, Password) || _user != null)
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
                        { "User", _user }
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
                if (IsNotRemembered)
                {
                    Password = string.Empty;
                    Username = string.Empty;
                }

                IsBusy = false;
            }
        }
    }
}
