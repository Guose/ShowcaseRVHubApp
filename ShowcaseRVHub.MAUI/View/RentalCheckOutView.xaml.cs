namespace ShowcaseRVHub.MAUI.View;

public partial class RentalCheckOutView : ContentPage
{
    public RentalCheckOutView(RentalCheckOutViewModel rentalViewModel)
	{
		InitializeComponent();

		BindingContext = rentalViewModel;
    }
}