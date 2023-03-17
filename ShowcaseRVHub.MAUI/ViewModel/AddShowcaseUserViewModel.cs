using ShowcaseRVHub.MAUI.Commands;
using ShowcaseRVHub.MAUI.Stores;
using System.Windows.Input;

namespace ShowcaseRVHub.MAUI.ViewModel
{
    public class AddShowcaseUserViewModel : ViewModelBase
    {
        public ShowcaseUserFormViewModel ShowcaseUserFormViewModel { get; }

        public AddShowcaseUserViewModel(ShowcaseUserStore showcaseUserStore, NavigationModalStore navigationModalStore)
        {
            //ICommand cancelCommand = new CloseModalCommand(navigationModalStore);
            ICommand submitCommand = new AddShowcaseUserCommand(showcaseUserStore, navigationModalStore);
            ShowcaseUserFormViewModel = new ShowcaseUserFormViewModel(submitCommand);
        }
    }
}
