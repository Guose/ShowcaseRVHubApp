namespace ShowcaseRVHub.MAUI.ViewModel.ComponentViewModel
{
    [QueryProperty(nameof(IsRenterTraining), "IsRenterTraining")]
    public partial class TravelerTrainingViewModel : ChecklistViewModel
    {
        [ObservableProperty]
        bool isRenterTraining;

        [ObservableProperty]
        bool isTrainingComplete;
    }
}
