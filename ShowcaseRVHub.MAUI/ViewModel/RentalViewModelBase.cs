namespace ShowcaseRVHub.MAUI.ViewModel
{
    public partial class RentalViewModelBase : ViewModelBase
    {
        public RentalViewModelBase() : base()
        {
            
        }

        [ObservableProperty]
        bool isExteriorCleaned;

        [ObservableProperty]
        bool isInteriorCleaned;

        [ObservableProperty]
        bool isTiresInspected;

        [ObservableProperty]
        bool isMaintenance;

        [ObservableProperty]
        bool isFluidChecked;

        [ObservableProperty]
        bool isSignalsChecked;

        [ObservableProperty]
        bool isSystemsChecked;

        [ObservableProperty]
        bool isRenterTrained;

        [ObservableProperty]
        DateTime startRental;

        [ObservableProperty]
        DateTime endRental;
    }
}
