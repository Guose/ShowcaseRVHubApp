using ShowcaseRVHub.MAUI.ViewModel;

namespace ShowcaseRVHub.MAUI.View
{
    public partial class MainView : ContentPage
    {
        private readonly TapGestureRecognizer _addUserTapped;
        private readonly TapGestureRecognizer _forgotPassword;
        public MainView()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();

            _addUserTapped = new TapGestureRecognizer();
            _forgotPassword = new TapGestureRecognizer();

            _addUserTapped.Tapped += CreateUser_Tapped;
            _forgotPassword.Tapped += ForgotPassword_Tapped;
        }

        private async void ForgotPassword_Tapped(object sender, TappedEventArgs e)
        {
            var forgotPasswordModal = new ForgotPasswordView();
            await Navigation.PushModalAsync(forgotPasswordModal);
        }

        private async void CreateUser_Tapped(object sender, TappedEventArgs e)
        {
            var addUserModal = new AddUserView();
            await Navigation.PushModalAsync(addUserModal);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            // Load the saved credentials if the user previously opted to remember them
            if (BindingContext is MainViewModel viewModel && viewModel.IsRemembered)
            {
                viewModel.Username = await SecureStorage.GetAsync("username").ConfigureAwait(false);
                viewModel.Password = await SecureStorage.GetAsync("password").ConfigureAwait(false);
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