namespace ShowcaseRVHub.MAUI.ViewModel.ComponentViewModel
{
    [QueryProperty(nameof(IsExteriorClean), "IsExteriorClean")]
    public partial class ExteriorCleaningViewModel : ViewModelBase
    {
        [ObservableProperty]
        bool isExteriorClean;

        [ObservableProperty]
        bool isExteriorComplete;
    }
}
