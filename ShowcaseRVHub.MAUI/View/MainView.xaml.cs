using LinqToDB;
using ShowcaseRVHub.MAUI.Model;
using ShowcaseRVHub.MAUI.Services.Interfaces;

namespace ShowcaseRVHub.MAUI.View
{
    public partial class MainView : ContentPage
    {
        private readonly TapGestureRecognizer _addUserTapped;
        private readonly TapGestureRecognizer _forgotPassword;
        private readonly IShowcaseUserDataService _dataService;
        private readonly IUserRepository _userRepository;
        private readonly IUserEmailService _userService;

        public MainView(IUserEmailService userService, IUserRepository userRepository, IShowcaseUserDataService dataService)
        {
            InitializeComponent();
            _dataService = dataService;
            _userRepository = userRepository;
            _userService = userService;

            BindingContext = new MainViewModel(_dataService);

            _addUserTapped = new TapGestureRecognizer();
            _forgotPassword = new TapGestureRecognizer();

            _addUserTapped.Tapped += CreateUser_Tapped;
            _forgotPassword.Tapped += ForgotPassword_Tapped;
        }
        

        private async void ForgotPassword_Tapped(object sender, TappedEventArgs e)
        {
            var forgotPasswordModal = new ForgotPasswordView(_userService, _userRepository, _dataService);
            await Navigation.PushModalAsync(forgotPasswordModal);
        }

        private async void CreateUser_Tapped(object sender, TappedEventArgs e)
        {
            var addUserModal = new AddUserView(_dataService);
            await Navigation.PushModalAsync(addUserModal);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            // Load the saved credentials if the user previously opted to remember them
            if (BindingContext is MainViewModel viewModel)
            {
                IQueryable<UserModel> users = await _dataService.GetAllUsersAsync();

                UserModel user = await users
                                        .OrderByDescending(m => m.ModifiedOn)
                                        .Where(u => u.IsRemembered == true)
                                        .FirstOrDefaultAsync();

                if (user != null)
                {
                    viewModel.Username = user.Username;
                    viewModel.Password = user.Password;
                }
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _addUserTapped.Tapped -= CreateUser_Tapped;
            _forgotPassword.Tapped -= ForgotPassword_Tapped;
        }
    }
}