using ShowcaseRVHub.MAUI.View;
using System.Runtime.CompilerServices;

namespace ShowcaseRVHub.MAUI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private Command _loginCommand;
        
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public Command LoginCommand => _loginCommand ??= new Command(OnLoginButtonClicked);

        private void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, value))
            {
                field = value;
                OnMyPropertyChanged(propertyName);
            }
        }

        private void OnLoginButtonClicked()
        {
            // Check the username and password against a database or other source of truth
            string username = Username;
            string password = Password;

            if (IsValid(username, password))
            {
                // Navigate to the main page
                Application.Current.MainPage = new MainPage();
            }
            else
            {
                // Display an error message
                Shell.Current.DisplayAlert("Login Failed", "Invalid username or password", "OK");
            }
        }

        private bool IsValid(string username, string password)
        {
            // TODO: Implement this method to check the username and password against a database or other source of truth
            return true;
        }
    }
}
