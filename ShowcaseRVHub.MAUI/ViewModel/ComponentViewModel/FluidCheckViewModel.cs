namespace ShowcaseRVHub.MAUI.ViewModel.ComponentViewModel
{
    [QueryProperty(nameof(IsFluidsCheck), "IsFluidCheck")]
    public partial class FluidCheckViewModel : ChecklistViewModel
    {
        [ObservableProperty]
        bool isFluidsCheck;

        [ObservableProperty]
        bool isFluidsCheckComplete;
    }
}
