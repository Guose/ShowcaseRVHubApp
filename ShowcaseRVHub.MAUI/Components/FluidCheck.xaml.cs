namespace ShowcaseRVHub.MAUI.Components;

public partial class FluidCheck : ContentView
{
	public FluidCheck()
	{
		InitializeComponent();

		BindingContext = new FluidCheckViewModel();
	}
}