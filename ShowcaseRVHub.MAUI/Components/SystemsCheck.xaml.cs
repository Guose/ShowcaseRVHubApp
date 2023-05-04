namespace ShowcaseRVHub.MAUI.Components;

public partial class SystemsCheck : ContentView
{
	public SystemsCheck()
	{
		InitializeComponent();

		BindingContext = new SystemsCheckViewModel();
	}
}