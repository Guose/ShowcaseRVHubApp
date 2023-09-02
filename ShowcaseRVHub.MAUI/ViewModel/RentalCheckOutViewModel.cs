namespace ShowcaseRVHub.MAUI.ViewModel
{
    [QueryProperty(nameof(RvModel), "RvModel")]
    [QueryProperty(nameof(User), "User")]
    [QueryProperty(nameof(ButtonText), "ButtonText")]
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

                IsBusy = true;

                if (RvModel == null) 
                    return;

                if (Renter == null)
                {
                    Renter = new RenterModel
                    {
                        Firstname = AddFirstName,
                        Lastname = AddLastName,
                        Email = AddEmail,
                        Phone = AddPhoneNumber,
                    };                   
                }

                if (Rental == null || Rental.RentalStart != StartRental || Rental.RentalEnd != EndRental)
                {
                    Rental = new RentalModel
                    {
                        RentalStart = StartRental,
                        RentalEnd = EndRental,
                    };
                }

                Parameters = new Dictionary<string, object>
                {
                    { "RvModel", RvModel },
                    { "Renter", Renter },
                    { "Rental", Rental },
                    { "User", User }
                };

                if (ButtonText == "Check Out")
                    IsCheckout = true;

                await Shell.Current.GoToAsync(
                    $"{nameof(ChecklistView)}?HeaderText={HeaderText}&IsCheckout={IsCheckout}&ButtonText={ButtonText}", 
                    true, Parameters);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> Unable to navigate to the next page. EXCEPTION: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally { IsBusy = false; }
        }
    }
}
