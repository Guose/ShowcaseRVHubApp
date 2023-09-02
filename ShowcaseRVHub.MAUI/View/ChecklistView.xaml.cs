namespace ShowcaseRVHub.MAUI.View;

public partial class ChecklistView : ContentPage
{
	private readonly ChecklistViewModel _checklistViewModel;
	public ChecklistView()
	{
		InitializeComponent();
		_checklistViewModel = new ChecklistViewModel();
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