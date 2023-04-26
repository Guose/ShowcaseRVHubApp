namespace ShowcaseRVHub.MAUI.View;

public partial class RVChecklistView : ContentPage
{
	public RVChecklistView()
	{
		InitializeComponent();
		BindingContext = new RVChecklistViewModel();
	}
}