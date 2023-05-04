namespace ShowcaseRVHub.MAUI.Components;

public partial class TireInspection : ContentView
{
	public TireInspection()
	{
		InitializeComponent();

		BindingContext = new TireInspectionViewModel();
	}
}