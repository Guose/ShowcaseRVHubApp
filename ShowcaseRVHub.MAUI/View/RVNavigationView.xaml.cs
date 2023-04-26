using ShowcaseRVHub.MAUI.ViewModel;

namespace ShowcaseRVHub.MAUI.View;

public partial class RVNavigationView : ContentPage
{
	public RVNavigationView(RVNavigationViewModel navViewModel)
	{
		InitializeComponent();
		BindingContext = navViewModel;
    }
}