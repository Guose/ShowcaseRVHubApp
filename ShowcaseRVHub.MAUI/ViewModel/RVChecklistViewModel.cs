namespace ShowcaseRVHub.MAUI.ViewModel
{
    [QueryProperty(nameof(RvModel), "RvModel")]
    [QueryProperty(nameof(ButtonText), nameof(ButtonText))]
    public partial class RVChecklistViewModel : ViewModelBase
    {
        [ObservableProperty]
        RVModel rvModel;

        [ObservableProperty]
        string buttonText;

        //[ObservableProperty]
        //bool isVisible;

        [ObservableProperty]
        bool isStartChecklist;

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        void StartCheckout() => IsStartChecklist = true;
    }
}
