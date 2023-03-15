using ShowcaseRVHub.Domain.Model;
using ShowcaseRVHub.MAUI.Stores;
using ShowcaseRVHub.MAUI.ViewModel;

namespace ShowcaseRVHub.MAUI.Commands
{
    public class AddShowcaseUserCommand : AsyncCommandBase
    {
        private readonly AddShowcaseUserViewModel _addShowcaseUserViewModel;
        private readonly ShowcaseUserStore _userStore;
        private readonly NavigationModalStore _navigationStore;

        public AddShowcaseUserCommand(ShowcaseUserStore userStore, NavigationModalStore navigationStore)
        {
            _userStore = userStore;
            _navigationStore = navigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            ShowcaseUserFormViewModel formUserModel = _addShowcaseUserViewModel.ShowcaseUserFormViewModel;
            
            formUserModel.ErrorMessage = string.Empty;

            formUserModel.IsSubmitting = true;

            try
            {
                ShowcaseUser showcaseUser = new(
                    Guid.NewGuid(),
                    formUserModel.Username,
                    formUserModel.Password,
                    formUserModel.Email);

                await _userStore.CreateAsync(showcaseUser);
                _navigationStore.Close();
            }
            catch (Exception)
            {
                formUserModel.ErrorMessage = "Failed to add Showcase user. Please try again later...";
            }
            finally { formUserModel.IsSubmitting = false; }
        }
    }
}
