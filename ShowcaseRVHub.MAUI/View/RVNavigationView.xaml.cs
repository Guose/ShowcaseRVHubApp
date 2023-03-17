using ShowcaseRVHub.MAUI.ViewModel;

namespace ShowcaseRVHub.MAUI.View;

public partial class RVNavigationView : ContentPage
{
	public RVNavigationView()
	{
		InitializeComponent();
		BindingContext = new RVNavigationViewModel();

    }
}