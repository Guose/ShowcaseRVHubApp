using ShowcaseRVHub.MAUI.ViewModel;

namespace ShowcaseRVHub.MAUI.View;

public partial class AddUserView : ContentPage
{
	public AddUserView()
	{
		InitializeComponent();
		BindingContext = new ShowcaseUserFormViewModel();
	}
}