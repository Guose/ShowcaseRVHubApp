namespace ShowcaseRVHub.MAUI.View;

public partial class AddUserView : ContentPage
{
	IShowcaseUserDataService _dataService;
	public AddUserView(IShowcaseUserDataService dataService)
	{
		_dataService = dataService;
		InitializeComponent();

		var userViewModel = new ShowcaseUserFormViewModel(_dataService);
		userViewModel.IsSubmitEnabled = false;
        BindingContext = userViewModel;
	}
}