namespace ShowcaseRVHub.MAUI.View;

public partial class RVChecklistView : ContentPage
{
	public RVChecklistView(RVChecklistViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}