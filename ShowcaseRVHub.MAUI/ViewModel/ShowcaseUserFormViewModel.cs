using ShowcaseRVHub.MAUI.Model;
using ShowcaseRVHub.MAUI.Services.Interfaces;

namespace ShowcaseRVHub.MAUI.ViewModel
{
    public partial class ShowcaseUserFormViewModel : ViewModelBase
    {
        IShowcaseUserDataService _dataService;
        UserModel _user;

        public ShowcaseUserFormViewModel() { }

        public ShowcaseUserFormViewModel(IShowcaseUserDataService dataService)
        {
            _dataService = dataService;
        }

        [ObservableProperty]
        string addEmail;

        [ObservableProperty]
        string addFirstName;

        [ObservableProperty]
        string addLastName;

        [ObservableProperty]
        string addPhoneNumber;
        
        public bool IsSubmitting { get; set; }
        public string ErrorMessage { get; set; }
        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);
        public bool CanSubmit =>             
            !string.IsNullOrEmpty(AddEmail) &&
            !string.IsNullOrEmpty(AddFirstName) &&
            !string.IsNullOrEmpty(AddLastName) &&
            !string.IsNullOrEmpty(Username) &&
            !string.IsNullOrEmpty(Password) &&
            !string.IsNullOrEmpty(ConfirmPassword);

        [RelayCommand]
        public async Task CreateUserAsync()
        {
            if (IsBusy || !IsMatch)
                return;

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
                    Email = AddEmail,
                    Phone = AddPhoneNumber,
                    Username = AddUsername,
                    Password = AddPassword,
                    CreatedOn = DateTime.UtcNow,
                };

                await _dataService.CreateUserAsync(_user);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to validate user: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally { IsBusy = false; }
        }

        [RelayCommand]
        public async Task CancelAsync()
        {
            await Shell.Current.Navigation.PopModalAsync();
        }
    }
}
