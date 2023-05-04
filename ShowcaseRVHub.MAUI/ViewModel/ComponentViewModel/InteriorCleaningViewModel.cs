namespace ShowcaseRVHub.MAUI.ViewModel.ComponentViewModel
{
    [QueryProperty(nameof(IsExteriorComplete), nameof(IsExteriorComplete))]
    public partial class InteriorCleaningViewModel : ViewModelBase
    {
        [ObservableProperty]
        bool isInteriorClean;

        [ObservableProperty]
        bool isInteriorComplete;

        [ObservableProperty]
        bool isExteriorComplete;
    }
}
