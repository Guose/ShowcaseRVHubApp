using ShowcaseRVHub.MAUI.Helpers;

namespace ShowcaseRVHub.MAUI.View;

public partial class ForgotPasswordView : ContentPage
{
	private readonly IUserEmailService _userService;
	private readonly IUserDataServiceHelper _userRepository;
	public ForgotPasswordView(IUserEmailService userService, IUserDataServiceHelper userRepository)
	{
		_userService = userService;
		_userRepository = userRepository;

		InitializeComponent();

        BindingContext = new ForgotPasswordViewModel(_userService, _userRepository);
    }
}