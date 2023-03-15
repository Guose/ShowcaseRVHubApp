using ShowcaseRVHub.MAUI.Commands;
using ShowcaseRVHub.MAUI.Stores;
using System.Windows.Input;

namespace ShowcaseRVHub.MAUI.ViewModel
{
    public class ShowcaseUserFormViewModel : ViewModelBase
    {
		private readonly INavigation _navigation;

        public ShowcaseUserFormViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }

		private string _email;
		public string Email
		{
			get
			{
				return _email;
			}
			set
			{
				_email = value;
				OnMyPropertyChanged(nameof(Email));
			}
		}
		private string _username;
		public string Username
		{
			get
			{
				return _username;
			}
			set
			{
				_username = value;
				OnMyPropertyChanged(nameof(Username));
			}
		}

		private string _password;
		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password = value;
				OnMyPropertyChanged(nameof(Password));
			}
		}

		private string _confirmPassword;
		public string ConfirmPassword
		{
			get
			{
				return _confirmPassword;
			}
			set
			{
				_confirmPassword = value;
				OnMyPropertyChanged(nameof(ConfirmPassword));
			}
		}

        public bool IsMatch
		{
			get => Password == ConfirmPassword;
		}

        private bool _isSubmitting;
        public bool IsSubmitting
        {
            get
            {
                return _isSubmitting;
            }
            set
            {
                _isSubmitting = value;
                OnMyPropertyChanged(nameof(IsSubmitting));
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnMyPropertyChanged(nameof(ErrorMessage));
                OnMyPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);
        public bool CanSubmit => !string.IsNullOrEmpty(Username);
        public ICommand SubmitCommand { get; set; }
		public ICommand CancelCommand => new Command(async () =>
		{
			await Shell.Current.Navigation.PopModalAsync();
		});


        public ShowcaseUserFormViewModel()
        {
            
        }
        public ShowcaseUserFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
			SubmitCommand = submitCommand;
            //CancelCommand = cancelCommand;
        }
    }
}
