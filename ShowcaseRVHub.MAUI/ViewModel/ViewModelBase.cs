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
        string username;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string confirmPassword;

        public bool IsMatch => Password == ConfirmPassword;
        public bool IsNotBusy => !IsBusy;

        [RelayCommand]
        public async Task CancelAsync()
        {
            await Shell.Current.Navigation.PopModalAsync();
        }

        protected virtual void Dispose() { }
    }
}
