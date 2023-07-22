namespace ShowcaseRVHub.MAUI.ViewModel
{
    [QueryProperty(nameof(RvModel), "RvModel")]
    [QueryProperty(nameof(Renter), "Renter")]
    [QueryProperty(nameof(Rental), "Rental")]
    [QueryProperty(nameof(User), "User")]
    [QueryProperty(nameof(HeaderText), "HeaderText")]
    [QueryProperty(nameof(IsCheckout), "IsCheckout")]
    public partial class ChecklistViewModel : RentalViewModelBase
    {
        public ChecklistViewModel() : base() { }

        [ObservableProperty]
        string headerText;

        [ObservableProperty]
        RVModel rvModel;

        [ObservableProperty]
        RenterModel renter;

        [ObservableProperty]
        RentalModel rental;

        [ObservableProperty]
        UserModel user;

        public bool IsCheckout { get; set; }

        public string SetLabelText()
        {
            return HeaderText;
        }
    }
}
