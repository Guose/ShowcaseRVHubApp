namespace ShowcaseRVHub.MAUI.ViewModel
{
    [QueryProperty(nameof(RvModel), "RvModel")]
    [QueryProperty(nameof(User), "User")]
    [QueryProperty(nameof(ButtonText), nameof(ButtonText))]
    public partial class RentalCheckOutViewModel : RentalViewModelBase
    {
        [ObservableProperty]
        RVModel rvModel;

        [ObservableProperty]
        RentalModel rental;

        [ObservableProperty]
        RenterModel renter;

        [ObservableProperty]
        UserModel user;

        [ObservableProperty]
        string buttonText;

        public RentalCheckOutViewModel()
        {
            Rental = new RentalModel();
        }

        public RentalCheckOutViewModel(DateTime startRental, DateTime endRental)
        {
            StartRental = startRental;
            EndRental = endRental;
            Rental = new RentalModel();
        }

        public Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();
        public Range SelectedRange { get; set; }
        public string HeaderText => $"{RvModel.Model} - {ButtonText}";
        public bool IsCheckout { get; set; }

        [RelayCommand]
        public async Task GoToCheckout()
        {
            if (IsBusy) return;

            try
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!",
                        $"Please check internet and try again.", "OK");
                    return;
                }

                if (RvModel == null) return;

                Renter = new RenterModel
                {
                    Firstname = AddFirstName,
                    Lastname = AddLastName,
                    Email = AddEmail,
                    Phone = AddPhoneNumber
                };

                Rental = new RentalModel
                {
                    RentalStart = StartRental,
                    RentalEnd = EndRental,
                };

                Parameters.Add("RvModel", RvModel);
                Parameters.Add("Renter", Renter);
                Parameters.Add("Rental", Rental);
                Parameters.Add("User", User);

                if (ButtonText == "Check Out")
                    IsCheckout = true;

                await Shell.Current.GoToAsync($"{nameof(ChecklistView)}?HeaderText={HeaderText}&IsCheckout={IsCheckout}", true, Parameters);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> Unable to navigate to the next page. EXCEPTION: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
        }

        internal void SetRentalCalendar(DateTime startRental, DateTime endRental)
        {
            StartRental = startRental;
            EndRental = endRental;
        }
    }
}
