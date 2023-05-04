namespace ShowcaseRVHub.MAUI.Components;

public partial class TravelerTraining : ContentView
{
	public TravelerTraining()
	{
		InitializeComponent();

		BindingContext = new TravelerTrainingViewModel();
	}
}