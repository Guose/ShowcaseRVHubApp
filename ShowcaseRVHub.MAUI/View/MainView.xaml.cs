using ShowcaseRVHub.MAUI.Helpers;

namespace ShowcaseRVHub.MAUI.View
{
    public partial class MainView : ContentPage
    {
        private readonly TapGestureRecognizer _addUserTapped;
        private readonly TapGestureRecognizer _forgotPassword;
        private readonly IShowcaseUserDataService _dataService;
        private readonly IUserDataServiceHelper _userRepository;
        private readonly IUserEmailService _userMailService;

        public MainView(IUserEmailService userMailService, IUserDataServiceHelper userRepository, IShowcaseUserDataService dataService)
        {
            InitializeComponent();
            _dataService = dataService;
            _userRepository = userRepository;
            _userMailService = userMailService;

            BindingContext = new MainViewModel(_dataService);

            _addUserTapped = new TapGestureRecognizer();
            _forgotPassword = new TapGestureRecognizer();

            _addUserTapped.Tapped += CreateUser_Tapped;
            _forgotPassword.Tapped += ForgotPassword_Tapped;
        }
        

        private async void ForgotPassword_Tapped(object sender, EventArgs e)
        {
            var forgotPasswordModal = new ForgotPasswordView(_userMailService, _userRepository);
            await Navigation.PushModalAsync(forgotPasswordModal);
        }

        private async void CreateUser_Tapped(object sender, EventArgs e)
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
                IEnumerable<UserModel> users = await _dataService.GetAllUsersAsync();

                if (users == null || !users.Any())
                {
                    Debug.WriteLine($"---> Unable to retrieve users. Database is NOT connected");
                    bool userResponse = await Shell.Current.DisplayAlert("Error! Database is NOT connected", "Server is not running...\nPlease contact tech support", "OK", "Cancel");

                    if (userResponse)
                    {
                        bool isOk = await Shell.Current.DisplayAlert("GOOD-BYE...", "Sorry for the inconvenience","OK", "Cancel");
                        
                        if (isOk)
                        {
                            // Close the app
                            Application.Current.Quit();
                        }
                    }
                }

                UserModel user = users
                                    .OrderByDescending(m => m.ModifiedOn)
                                    .Where(u => u.IsRemembered == true)
                                    .SingleOrDefault();

                if (user != null)
                {
                    viewModel.Username = user.Username;
                    viewModel.Password = user.Password;
                    viewModel.IsRemembered = true;
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