using ShowcaseRVHub.MAUI.Services.Interfaces;

namespace ShowcaseRVHub.MAUI.View;

public partial class ForgotPasswordView : ContentPage
{
	private readonly IUserEmailService _userService;
	private readonly IShowcaseUserDataService _showcaseUserDataService;
	private readonly IUserRepository _userRepository;
	public ForgotPasswordView(IUserEmailService userService, IUserRepository userRepository, IShowcaseUserDataService showcaseUserDataService)
	{
		_userService = userService;
		_userRepository = userRepository;
		_showcaseUserDataService = showcaseUserDataService;

		InitializeComponent();

        BindingContext = new ForgotPasswordViewModel(_userService, _userRepository, _showcaseUserDataService);
    }
}