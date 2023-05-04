using ShowcaseRVHub.MAUI.Components;

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

        [ObservableProperty]
        bool isStartChecklist;

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async void StartCheckout()
        {
            try
            {
                if (RvModel == null)
                    return;

                IsStartChecklist = true;

                await Shell.Current.GoToAsync($"{nameof(ChecklistView)}?IsStartChecklist={IsStartChecklist}", true,
                    new Dictionary<string, object>
                    {
                        { "RvModel", RvModel }
                    });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> Unable to navigate to the next page. EXCEPTION: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
        }
    }
}
