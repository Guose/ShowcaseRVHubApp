namespace ShowcaseRVHub.MAUI.ViewModel
{
    public partial class ViewModelBase : ObservableObject
    {
        string _password;
        string _confirmPassword;
        bool _isSubmitEnabled;
        public ViewModelBase()
        {
            _isSubmitEnabled = false;
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        string username;

        public bool IsSubmitEnabled
        {
            get => _isSubmitEnabled;
            set
            {
                SetProperty(ref _isSubmitEnabled, value);
                OnPropertyChanged(nameof(IsSubmitEnabled));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value);
            }
        }
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                SetProperty(ref _confirmPassword, value);
                CheckFormValidity();
            }
        }

        private void CheckFormValidity()
        {
            if (Password == ConfirmPassword && !string.IsNullOrEmpty(Password))
                IsSubmitEnabled = true;
            else
                IsSubmitEnabled = false;
        }
        public bool IsNotBusy => !IsBusy;        

        [RelayCommand]
        public async Task CancelAsync()
        {
            await Shell.Current.Navigation.PopModalAsync();
        }

        protected virtual void Dispose() 
        {
            IsSubmitEnabled = false;
            Password = null;
        }
    }
}
