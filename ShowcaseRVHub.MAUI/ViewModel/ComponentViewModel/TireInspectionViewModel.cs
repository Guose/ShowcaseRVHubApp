namespace ShowcaseRVHub.MAUI.ViewModel.ComponentViewModel
{
    [QueryProperty(nameof(IsTireInspection), "IsTireInspection")]
    public partial class TireInspectionViewModel : ChecklistViewModel
    {
        [ObservableProperty]
        bool isTireInspection;

        [ObservableProperty]
        bool isTireInspectionComplete;
    }
}
