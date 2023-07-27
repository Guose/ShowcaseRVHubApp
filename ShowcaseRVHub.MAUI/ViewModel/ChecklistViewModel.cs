namespace ShowcaseRVHub.MAUI.ViewModel
{
    [QueryProperty(nameof(RvModel), "RvModel")]
    [QueryProperty(nameof(Renter), "Renter")]
    [QueryProperty(nameof(Rental), "Rental")]
    [QueryProperty(nameof(User), "User")]
    [QueryProperty(nameof(HeaderText), "HeaderText")]
    [QueryProperty(nameof(IsCheckout), "IsCheckout")]
    public partial class ChecklistViewModel : RentalViewModelBase
    {
        List<RenterModel> _renters;
        readonly IRentalDataService _rentalDataService;
        readonly IRenterDataService _renterDataService;
        public ChecklistViewModel(IRentalDataService rentalDataService) : base()
        {
            _rentalDataService = rentalDataService;
            _renterDataService = new RenterDataService();
            _renters = new List<RenterModel>();
        }

        [ObservableProperty]
        string headerText;

        [ObservableProperty]
        RVModel rvModel;

        [ObservableProperty]
        RenterModel renter;

        [ObservableProperty]
        RentalModel rental;

        [ObservableProperty]
        UserModel user;


        public bool IsCheckout { get; set; }

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

                _renters = await _renterDataService.GetAllRentersAsync() as List<RenterModel>;
                Renter = _renters.FirstOrDefault(r => r.Firstname == Renter.Firstname && r.Lastname == Renter.Lastname);

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
                        UserId = User.Id,
                        RVId = RvModel.Id
                    };
                    await _rentalDataService.CreateRentalAsync(rental);
                }

                await Shell.Current.GoToAsync($"{nameof(ConsentAgreementView)}?HeaderText={HeaderText}&IsCheckout={IsCheckout}", true, 
                    new Dictionary<string, object>
                    {
                        { "RvModel", RvModel }
                    });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] ---> Unable to complete Rental: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
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
