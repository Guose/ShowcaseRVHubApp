namespace ShowcaseRVHub.MAUI.View;

public partial class ChecklistView : ContentPage
{
	private readonly ChecklistViewModel _checklistViewModel;
	private IRentalDataService _rentalDataService;
	public ChecklistView(IRentalDataService rentalDataService)
	{
		_rentalDataService = rentalDataService;
		InitializeComponent();
		_checklistViewModel = new ChecklistViewModel(_rentalDataService);
		BindingContext = _checklistViewModel;
	}

    private void RenterTrained_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		SetStateOfSubmitButton(e.Value);
    }

	private void SetStateOfSubmitButton(bool isChecked)
	{
		if (isChecked)
			_checklistViewModel.SetbuttonVisibility();
		else
			_checklistViewModel.IsButtonEnabled = false;
	}
}