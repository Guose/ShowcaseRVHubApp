namespace ShowcaseRVHub.MAUI.ViewModel
{
    public class ForgotPasswordViewModel : ViewModelBase
    {
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
				OnPropertyChanged(nameof(Email));
			}
		}
	}
}
