namespace ShowcaseRVHub.MAUI.Components;

public partial class InteriorCleaning : ContentView
{
    public InteriorCleaning()
	{
		InitializeComponent();
		BindingContext = new InteriorCleaningViewModel();
	}
}