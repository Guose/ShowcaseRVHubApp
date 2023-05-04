namespace ShowcaseRVHub.MAUI.ViewModel
{
    [QueryProperty(nameof(IsStartChecklist), "IsStartChecklist")]
    [QueryProperty(nameof(RvModel), "RvModel")]
    public partial class ChecklistViewModel : ViewModelBase
    {
        [ObservableProperty]
        RVModel rvModel;

        [ObservableProperty]
        bool isStartChecklist;

        [ObservableProperty]
        bool isExteriorComplete;

        [ObservableProperty]
        bool isInteriorComplete;

        [ObservableProperty]
        bool isTireInspectionComplete;

        [ObservableProperty]
        bool isRoutineMaintenanceComplete;

        [ObservableProperty]
        bool isFluidsCheckComplete;

        [ObservableProperty]
        bool isSignalsCheckComplete;

        [ObservableProperty]
        bool isSystemsCheckComplete;

        [ObservableProperty]
        bool isTrainingComplete;

        [ObservableProperty]
        bool isTrainerSign;

        [ObservableProperty]
        bool isRenterSign;

        public bool IsButtonEnabled => EnableButton();

        private bool EnableButton()
        {
            if (IsTrainerSign && IsRenterSign)
                return true;
            else
                return false;
        }
    }
}
