namespace ShowcaseRVHub.MAUI.View;

public partial class ConsentAgreementView : ContentPage
{
	public ConsentAgreementView(ConsentAgreementViewModel consentAgreementViewModel)
	{
		InitializeComponent();

		BindingContext = consentAgreementViewModel;
	}
}