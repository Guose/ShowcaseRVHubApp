namespace ShowcaseRVHub.MAUI.Components;

public partial class ChecklistView : ContentPage
{
	public ChecklistView()
	{
		InitializeComponent();
		BindingContext = new ChecklistViewModel();
    }
}