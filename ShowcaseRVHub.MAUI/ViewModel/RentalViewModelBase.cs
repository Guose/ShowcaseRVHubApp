namespace ShowcaseRVHub.MAUI.ViewModel
{
    public partial class RentalViewModelBase : ViewModelBase
    {
        public RentalViewModelBase() : base()
        {
            
        }

        public Dictionary<string, object> Parameters { get; set; }

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
        [NotifyPropertyChangedFor(nameof(IsNotVisible))]
        bool isRenterTrained;

        public bool IsNotVisible => !IsRenterTrained;

        [ObservableProperty]
        DateTime startRental;

        [ObservableProperty]
        DateTime endRental;
    }
}
