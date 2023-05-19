namespace ShowcaseRVHub.MAUI.ViewModel
{
    public partial class ShowcaseUserFormViewModel : ViewModelBase
    {
        IShowcaseUserDataService _dataService;
        UserModel _user;

        public ShowcaseUserFormViewModel()
        {
            IsSubmitEnabled = false;
        }

        public ShowcaseUserFormViewModel(IShowcaseUserDataService dataService)
        {
            _dataService = dataService;
            IsSubmitEnabled = false;
        }

        [ObservableProperty]
        string addEmail;

        [ObservableProperty]
        string addFirstName;

        [ObservableProperty]
        string addLastName;

        [ObservableProperty]
        string addPhoneNumber;       
        

        public bool IsMatch => Password == ConfirmPassword && !string.IsNullOrEmpty(Password) || !string.IsNullOrEmpty(ConfirmPassword);

        public bool CanSubmit => CanBeSubmitted();

        public string ErrorMessage { get; set; }
        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        public bool CanBeSubmitted()
        {
            if (!string.IsNullOrEmpty(AddEmail) &&
            !string.IsNullOrEmpty(AddFirstName) &&
            !string.IsNullOrEmpty(AddLastName) &&
            !string.IsNullOrEmpty(Username) &&
            !string.IsNullOrEmpty(Password) &&
            !string.IsNullOrEmpty(ConfirmPassword))
                return true;
            else
                return false;
        }
            

        [RelayCommand]
        public async Task CreateUserAsync()
        {
            if (IsBusy || !IsMatch)
            {
                await Shell.Current.DisplayAlert("Check Passwords",
                        $"Passwords need to match and cannot be blank.", "OK");
                return;
            }

            try
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!",
                        $"Please check internet and try again.", "OK");
                    return;
                }

                IsBusy = true;

                // Add user to database
                _user = new UserModel
                {
                    Id = Guid.NewGuid(),
                    FirstName = AddFirstName,
                    LastName = AddLastName,
                    Email = AddEmail.ToLower(),
                    Phone = AddPhoneNumber,
                    Username = Username,
                    Password = Password,
                    CreatedOn = DateTime.UtcNow,
                };

                await _dataService.CreateUserAsync(_user);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to validate user: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally 
            {
                await Shell.Current.GoToAsync("..").WaitAsync(TimeSpan.FromSeconds(1));
                MainViewModel mvm = new(_dataService);
                IsBusy = false; 
            }
        }        
    }
}
