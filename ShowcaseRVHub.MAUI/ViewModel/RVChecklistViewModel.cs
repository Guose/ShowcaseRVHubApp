using ShowcaseRVHub.MAUI.Model;

namespace ShowcaseRVHub.MAUI.ViewModel
{
    [QueryProperty(nameof(RVModel), "RVModel")]
    public partial class RVChecklistViewModel : ViewModelBase
    {
        [ObservableProperty]
        RVModel rVModel;

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
