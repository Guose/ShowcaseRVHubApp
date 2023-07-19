namespace ShowcaseRVHub.MAUI.View;

public partial class RentalCheckOutView : ContentPage
{
    public RentalCheckOutView()
	{
		InitializeComponent();

		BindingContext = new RentalCheckOutViewModel();
    }
}