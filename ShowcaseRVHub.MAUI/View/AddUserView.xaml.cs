using ShowcaseRVHub.MAUI.Services.Interfaces;
using ShowcaseRVHub.MAUI.ViewModel;

namespace ShowcaseRVHub.MAUI.View;

public partial class AddUserView : ContentPage
{
	IShowcaseUserDataService _dataService;
	public AddUserView(IShowcaseUserDataService dataService)
	{
		_dataService = dataService;
		InitializeComponent();
		BindingContext = new ShowcaseUserFormViewModel(_dataService);
	}
}