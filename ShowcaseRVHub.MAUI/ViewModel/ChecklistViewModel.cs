namespace ShowcaseRVHub.MAUI.ViewModel
{
    [QueryProperty(nameof(RvModel), "RvModel")]
    [QueryProperty(nameof(HeaderText), "HeaderText")]
    [QueryProperty(nameof(IsCheckout),"IsCheckout")]
    public partial class ChecklistViewModel : ViewModelBase
    {
        [ObservableProperty]
        string headerText;

        [ObservableProperty]
        RVModel rvModel;

        public bool IsCheckout { get; set; }

        public string SetLabelText()
        {
            return HeaderText;
        }
    }
}
