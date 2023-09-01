namespace ShowcaseRVHub.MAUI.ViewModel
{
    [QueryProperty(nameof(IsCheckout), "IsCheckout")]
    [QueryProperty(nameof(HeaderText), "HeaderText")]
    public partial class ConsentAgreementViewModel : ViewModelBase
    {
        [ObservableProperty]
        bool isUserSigned;

        [ObservableProperty]
        bool isRenterSigned;

        [ObservableProperty]
        bool isCheckout;

        [ObservableProperty]
        string headerText;
    }
}
