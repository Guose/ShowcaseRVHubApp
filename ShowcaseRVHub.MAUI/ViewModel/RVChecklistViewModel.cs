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

        public Range SelectedRange { get; set; }
        public string HeaderText => $"{RvModel.Model} - {ButtonText}";
        public bool IsCheckout { get; set; }

        [RelayCommand]
        public async Task GoToChecklist()
        {
            try
            {
                if (RvModel == null)
                    return;
                if (ButtonText == "Check Out")
                    IsCheckout = true;

                await Shell.Current.GoToAsync($"{nameof(ChecklistView)}?HeaderText={HeaderText}&IsCheckout={IsCheckout}", true,
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
