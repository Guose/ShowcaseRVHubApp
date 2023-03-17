

namespace ShowcaseRVHub.MAUI.ViewModel
{
    public partial class ShowcaseUserFormViewModel : ViewModelBase
    {
        public ShowcaseUserFormViewModel()
        {
            
        }
        public ShowcaseUserFormViewModel(ICommand submitCommand)
        {
            SubmitCommand = submitCommand;
        }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
        public bool IsRemembered { get; set; }
        public bool IsMatch  => Password == ConfirmPassword;
        public bool IsSubmitting { get; set; }
        public string ErrorMessage { get; set; }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);
        public bool CanSubmit => !string.IsNullOrEmpty(Username);
        public ICommand SubmitCommand { get; set; }
		public ICommand CancelCommand => new Command(async () =>
		{
			await Shell.Current.Navigation.PopModalAsync();
		});
        
    }
}
