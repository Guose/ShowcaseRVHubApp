namespace ShowcaseRVHub.MAUI.ViewModel.ComponentViewModel
{
    [QueryProperty(nameof(IsSignalsCheck), "IsSignalsCheck")]
    public partial class SignalsCheckViewModel : ChecklistViewModel
    {
        [ObservableProperty]
        bool isSignalsCheck;

        [ObservableProperty]
        bool isSignalsCheckComplete;
    }
}
