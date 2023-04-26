using LinqToDB;

namespace ShowcaseRVHub.MAUI.View;

public partial class RVSelectorView : ContentPage
{
	public RVSelectorView()
	{
		InitializeComponent();
		BindingContext = new RVSelectorViewModel();
	}
}