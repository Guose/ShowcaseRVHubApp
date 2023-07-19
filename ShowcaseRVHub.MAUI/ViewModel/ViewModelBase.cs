namespace ShowcaseRVHub.MAUI.ViewModel
{
    public partial class ViewModelBase : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        string addFirstName;

        [ObservableProperty]
        string addLastName;

        [ObservableProperty]
        string addEmail;

        [ObservableProperty]
        string addPhoneNumber;

        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string confirmPassword;
        public bool IsNotBusy => !IsBusy;        

        [RelayCommand]
        public async Task CancelAsync()
        {
            await Shell.Current.Navigation.PopModalAsync();
        }

        protected virtual void Dispose() 
        {
            Password = null;
        }
    }
}
