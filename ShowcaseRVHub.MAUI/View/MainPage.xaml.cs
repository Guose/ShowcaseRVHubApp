using ShowcaseRVHub.MAUI.View;
using ShowcaseRVHub.MAUI.ViewModel;

namespace ShowcaseRVHub.MAUI.View
{
    public partial class MainPage : ContentPage
    {
        private readonly TapGestureRecognizer _addUserTapped;
        private readonly TapGestureRecognizer _forgotPassword;
        public MainPage()
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
            var forgotPasswordModal = new ForgotPasswordPage();
            await Navigation.PushModalAsync(forgotPasswordModal);
        }

        private async void CreateUser_Tapped(object sender, TappedEventArgs e)
        {
            var addUserModal = new AddUserPage();
            await Navigation.PushModalAsync(addUserModal);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _addUserTapped.Tapped -= CreateUser_Tapped;
            _forgotPassword.Tapped -= ForgotPassword_Tapped;
        }
    }
}