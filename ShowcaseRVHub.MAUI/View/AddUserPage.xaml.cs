using ShowcaseRVHub.MAUI.ViewModel;

namespace ShowcaseRVHub.MAUI.View;

public partial class AddUserPage : ContentPage
{
	public AddUserPage()
	{
		InitializeComponent();
		BindingContext = new ShowcaseUserFormViewModel();
	}
}