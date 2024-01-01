using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShowcaseRVHub.MAUI.ViewModel
{
    public partial class ViewModelBase : ObservableObject //, INotifyPropertyChanged
    {
        // public event PropertyChangedEventHandler PropertyChanged;
        // protected new virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        // {
        //     PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        // }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsButtonNotEnabled))]
        bool isButtonEnabled;

        public bool IsButtonNotEnabled 
        { 
            get => !IsButtonEnabled; 
            set
            {
                IsButtonEnabled = !value;
            }
        }

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
        protected virtual async Task CancelAsync()
        {
            await Shell.Current.Navigation.PopModalAsync();
        }

        protected virtual void Dispose() 
        {
            Password = null;
        }
    }
}
