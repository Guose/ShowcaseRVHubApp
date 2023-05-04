namespace ShowcaseRVHub.MAUI.ViewModel.ComponentViewModel
{
    [QueryProperty(nameof(IsRoutineMaintenance), "IsRoutineMaintenance")]
    public partial class RoutineMaintenanceViewModel : ChecklistViewModel
    {
        [ObservableProperty]
        bool isRoutineMaintenance;

        [ObservableProperty]
        bool isRoutineMaintenanceComplete;
    }
}
