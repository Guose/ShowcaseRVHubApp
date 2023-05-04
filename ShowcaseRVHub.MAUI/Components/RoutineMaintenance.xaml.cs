namespace ShowcaseRVHub.MAUI.Components;

public partial class RoutineMaintenance : ContentView
{
	public RoutineMaintenance()
	{
		InitializeComponent();

		BindingContext = new RoutineMaintenanceViewModel();
	}
}