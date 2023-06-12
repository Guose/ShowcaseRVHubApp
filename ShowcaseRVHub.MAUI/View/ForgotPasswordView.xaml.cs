using ShowcaseRVHub.MAUI.Services.Interfaces;

namespace ShowcaseRVHub.MAUI.View;

public partial class ForgotPasswordView : ContentPage
{
	private readonly IUserEmailService _userService;
	private readonly IUserRepository _userRepository;
	public ForgotPasswordView(IUserEmailService userService, IUserRepository userRepository)
	{
		_userService = userService;
		_userRepository = userRepository;

		InitializeComponent();

        BindingContext = new ForgotPasswordViewModel(_userService, _userRepository);
    }
}