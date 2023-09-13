namespace ShowcaseRVHub.MAUI.View;

public partial class ChecklistView : ContentPage
{
	public ChecklistView(ChecklistViewModel checklistViewModel)
	{
		InitializeComponent();

        BindingContext = checklistViewModel;
	}

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        // Check if at least one RadioButton is selected in each group
        bool fuelSelected = FuelEmpty.IsChecked || FuelQuarter.IsChecked || FuelHalf.IsChecked || FuelThreeQuarter.IsChecked || FuelFull.IsChecked;
        bool propaneSelected = PropaneEmpty.IsChecked || PropaneQuarter.IsChecked || PropaneHalf.IsChecked || PropaneThreeQuarter.IsChecked || PropaneFull.IsChecked;
        bool grayWaterSelected = GrayWaterEmpty.IsChecked || GrayWaterQuarter.IsChecked || GrayWaterHalf.IsChecked || GrayWaterThreeQuarter.IsChecked || GrayWaterFull.IsChecked;
        bool blackWaterSelected = BlackWaterEmpty.IsChecked || BlackWaterQuarter.IsChecked || BlackWaterHalf.IsChecked || BlackWaterThreeQuarter.IsChecked || BlackWaterFull.IsChecked;

        // Enable the "FluidCheck" CheckBox when at least one RadioButton from each group is selected
        FluidCheck.IsEnabled = fuelSelected && propaneSelected && grayWaterSelected && blackWaterSelected;
    }
}