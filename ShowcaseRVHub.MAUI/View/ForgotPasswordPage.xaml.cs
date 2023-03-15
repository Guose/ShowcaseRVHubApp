using ShowcaseRVHub.MAUI.ViewModel;

namespace ShowcaseRVHub.MAUI.View;

public partial class ForgotPasswordPage : ContentPage
{
	public ForgotPasswordPage()
	{
		InitializeComponent();
		BindingContext = new ShowcaseUserFormViewModel();
	}
}