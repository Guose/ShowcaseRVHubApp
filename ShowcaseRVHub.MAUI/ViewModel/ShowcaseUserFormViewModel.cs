using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace ShowcaseRVHub.MAUI.ViewModel
{
    public partial class ShowcaseUserFormViewModel : ViewModelBase
    {
        IShowcaseUserDataService _dataService;
        UserModel _user;
        public ShowcaseUserFormViewModel(IShowcaseUserDataService dataService) : base()
        {
            _dataService = dataService;
            UpdateButtonEnabledState();
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsButtonNotEnabled))]
        bool isButtonEnabled;

        public bool IsMatch => Password == ConfirmPassword && !string.IsNullOrEmpty(Password) || !string.IsNullOrEmpty(ConfirmPassword);
        public bool IsButtonNotEnabled => !IsButtonEnabled;

        public string ErrorMessage { get; set; }
        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        public void UpdateButtonEnabledState()
        {
            IsButtonEnabled = IsMatch
                && !string.IsNullOrEmpty(AddFirstName)
                && !string.IsNullOrEmpty(AddLastName)
                && !string.IsNullOrEmpty(AddEmail)
                && !string.IsNullOrEmpty(Username);
        }

        [RelayCommand]
        public async Task CreateUserAsync()
        {
            if (IsBusy)
                return;

            if (!IsMatch)
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
                    CreatedOn = DateTime.Now,
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

        public static explicit operator ShowcaseUserFormViewModel(Entry v)
        {
            throw new NotImplementedException();
        }
    }
}
