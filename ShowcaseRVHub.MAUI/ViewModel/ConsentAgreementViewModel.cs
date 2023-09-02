namespace ShowcaseRVHub.MAUI.ViewModel
{
    [QueryProperty(nameof(IsCheckout), "IsCheckout")]
    [QueryProperty(nameof(HeaderText), "HeaderText")]
    [QueryProperty(nameof(Renter), "Renter")]
    [QueryProperty(nameof(Rental), "Rental")]
    public partial class ConsentAgreementViewModel : ViewModelBase
    {
        private readonly IRentalDataService _rentalDataService;
        private readonly IRenterDataService _renterDataService;
        public ConsentAgreementViewModel(IRentalDataService rentalDataService, IRenterDataService renterDataService)
        {
            _rentalDataService = rentalDataService;
            _renterDataService = renterDataService;
        }

        [ObservableProperty]
        RenterModel renter;

        [ObservableProperty]
        RentalModel rental;

        [ObservableProperty]
        bool isUserSigned;

        [ObservableProperty]
        bool isRenterSigned;

        [ObservableProperty]
        bool isCheckout;

        [ObservableProperty]
        string headerText;

        [RelayCommand]
        public async Task SubmitRental()
        {
            try
            {
                if (IsBusy)
                    return;

                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!",
                        $"Please check internet and try again.", "OK");
                    return;
                }

                IsBusy = true;

                if (!await _renterDataService.CreateRenterAsync(Renter))
                {
                    Debug.WriteLine($"---> Unable to Create Renter to the database.");
                    await Shell.Current.DisplayAlert("Error!", "Please enter Renter and try again.", "OK");
                    return;
                }
                if (!await _rentalDataService.CreateRentalAsync(Rental))
                {
                    Debug.WriteLine($"---> Unable to Create Rental to the database.");
                    await Shell.Current.DisplayAlert("Error!", "Please enter Renter and try again.", "OK");
                    return;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] ---> Unable to complete Rental: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally { IsBusy = false; }
        }
    }
}
