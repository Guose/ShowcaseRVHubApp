namespace ShowcaseRVHub.MAUI.ViewModel
{
    [QueryProperty(nameof(RvModel), "RvModel")]
    [QueryProperty(nameof(Renter), "Renter")]
    [QueryProperty(nameof(Rental), "Rental")]
    [QueryProperty(nameof(User), "User")]
    [QueryProperty(nameof(HeaderText), "HeaderText")]
    [QueryProperty(nameof(IsCheckout), "IsCheckout")]
    [QueryProperty(nameof(ButtonText), "ButtonText")]
    public partial class ChecklistViewModel : RentalViewModelBase
    {
        [ObservableProperty]
        string headerText;

        [ObservableProperty]
        string buttonText;

        [ObservableProperty]
        bool isCheckout;

        [ObservableProperty]
        RVModel rvModel;

        [ObservableProperty]
        RenterModel renter;

        [ObservableProperty]
        RentalModel rental;

        [ObservableProperty]
        UserModel user;

        [RelayCommand]
        public async Task CompleteRental()
        {
            if (IsBusy)
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

                if (Renter != null)
                {
                    // use create rental api
                    RentalModel rental = new RentalModel
                    {
                        IsExteriorCleaned = IsExteriorCleaned,
                        IsInteriorCleaned = IsInteriorCleaned,
                        IsFluidChecked = IsFluidChecked,
                        IsMaintenance = IsMaintenance,
                        IsSignalChecked = IsSignalsChecked,
                        IsSystemsChecked = IsSystemsChecked,
                        IsTiresInspected = IsTiresInspected,
                        IsRenterTrained = IsRenterTrained,
                        RentalStart = Rental.RentalStart,
                        RentalEnd = Rental.RentalEnd,
                        RenterId = Renter.Id,
                        Renter = Renter,
                        UserId = User.Id,
                        User = User,
                        RVId = RvModel.Id,
                        RVModel = RvModel
                    };
                }

                Parameters = new Dictionary<string, object>
                {
                    { "RvModel", RvModel },
                    { "Renter", Renter },
                    { "Rental", Rental },
                    { "User", User }
                };

                await Shell.Current.GoToAsync(
                    $"{nameof(ConsentAgreementView)}?HeaderText={HeaderText}&IsCheckout={IsCheckout}", 
                    true, Parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] ---> Unable to complete Rental: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally { IsBusy = false; }
        }

        protected async override Task CancelAsync()
        {
            await base.CancelAsync().ContinueWith(t =>
            {
                
            });
        }

        public bool SetbuttonVisibility()
        {
            return IsButtonEnabled = (IsExteriorCleaned
                && IsInteriorCleaned
                && IsTiresInspected
                && IsMaintenance
                && IsFluidChecked
                && IsSignalsChecked
                && IsSystemsChecked
                && IsRenterTrained);
        }
    }
}
