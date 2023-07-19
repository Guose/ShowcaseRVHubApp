namespace ShowcaseRVHub.MAUI.View;

public partial class AddUserView : ContentPage
{
    readonly IShowcaseUserDataService _dataService;
	private ShowcaseUserFormViewModel _userViewModel;
    public AddUserView(IShowcaseUserDataService dataService)
	{
		_dataService = dataService;
		InitializeComponent();

        _userViewModel = new ShowcaseUserFormViewModel(_dataService);
        _userViewModel.IsButtonEnabled = false;
        BindingContext = _userViewModel;
	}

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        SetStateOfSubmitButton(e.NewTextValue);
    }

    private void SetStateOfSubmitButton(string entryValue)
    {
        if (entryValue == _userViewModel.Password)
            _userViewModel.UpdateButtonEnabledState();
        else
            _userViewModel.IsButtonEnabled = false;
    }
}