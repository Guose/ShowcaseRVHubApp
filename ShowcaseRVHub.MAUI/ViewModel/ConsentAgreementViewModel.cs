namespace ShowcaseRVHub.MAUI.ViewModel
{
    [QueryProperty(nameof(IsCheckout), "IsCheckout")]
    public partial class ConsentAgreementViewModel : ViewModelBase
    {
        [ObservableProperty]
        bool isUserSigned;

        [ObservableProperty]
        bool isRenterSigned;

        [ObservableProperty]
        bool isCheckout;
    }
}
