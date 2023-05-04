namespace ShowcaseRVHub.MAUI.ViewModel.ComponentViewModel
{
    [QueryProperty(nameof(IsSystemsCheck), "IsSystemsCheck")]
    public partial class SystemsCheckViewModel : ChecklistViewModel
    {
        [ObservableProperty]
        bool isSystemsCheck;

        [ObservableProperty]
        bool isSystemsCheckComplete;
    }
}
