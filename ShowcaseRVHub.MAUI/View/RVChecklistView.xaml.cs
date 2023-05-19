namespace ShowcaseRVHub.MAUI.View;

public partial class RVChecklistView : ContentPage
{
	public RVChecklistView(RVChecklistViewModel vm)
	{
		InitializeComponent();
		//vm.IsVisible = true;
		BindingContext = vm;
	}
}