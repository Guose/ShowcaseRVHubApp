namespace ShowcaseRVHub.MAUI.Components;

public partial class SignalsCheck : ContentView
{
	public SignalsCheck()
	{
		InitializeComponent();

		BindingContext = new SignalsCheckViewModel();
	}
}