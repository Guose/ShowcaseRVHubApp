namespace ShowcaseRVHub.MAUI.View;

public partial class ChecklistView : ContentPage
{
	public ChecklistView(ChecklistViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}