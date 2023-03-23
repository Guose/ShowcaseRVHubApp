using ShowcaseRVHub.MAUI.ViewModel;
using Windows.Devices.AllJoyn;

namespace ShowcaseRVHub.MAUI.View;

public partial class ForgotPasswordView : ContentPage
{
    private readonly ForgotPasswordViewModel viewModel;
	public ForgotPasswordView()
	{
		InitializeComponent();
        viewModel = (ForgotPasswordViewModel)BindingContext;
    }

    async void OnResetPasswordClicked(object sender, EventArgs e)
    {
        await viewModel.ResetPasswordAsync();

        if (viewModel.IsPasswordResetSuccessful)
            await DisplayAlert("Password Reset", "Your password has been reset", "OK");
        else
            await DisplayAlert("Password Reset Failed", "Please check your email address and try again", "OK");
    }

    private async void OnRetrieveUsernameClicked(object sender, EventArgs e)
    {
        await viewModel.RetrieveUsernameAsync();

        if (viewModel.IsPasswordResetSuccessful)
            await DisplayAlert("Username Retrieval", $"Your username has been sent to {viewModel.ForgotPasswordEmail}", "OK");
        else
            await DisplayAlert("Username Retrieval Failed", "Please check your email address and try again", "OK");
    }
}