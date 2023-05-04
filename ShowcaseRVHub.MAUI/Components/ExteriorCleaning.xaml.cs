namespace ShowcaseRVHub.MAUI.Components;

public partial class ExteriorCleaning : ContentView
{
    public ExteriorCleaning()
	{
		InitializeComponent();
		BindingContext = new ExteriorCleaningViewModel();
	}
}