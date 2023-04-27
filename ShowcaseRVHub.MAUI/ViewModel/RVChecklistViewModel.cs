using ShowcaseRVHub.MAUI.Model;

namespace ShowcaseRVHub.MAUI.ViewModel
{
    [QueryProperty(nameof(RVModel), "RVModel")]
    [QueryProperty(nameof(RVChecklistModel), "RVChecklistModel")]
    public partial class RVChecklistViewModel : ViewModelBase
    {
        [ObservableProperty]
        RVModel rVModel;

        [ObservableProperty]
        RVChecklistModel rVChecklistModel;

        [ObservableProperty]
        string buttonText;

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
