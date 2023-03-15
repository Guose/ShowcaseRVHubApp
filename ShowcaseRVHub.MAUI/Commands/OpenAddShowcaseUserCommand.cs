using ShowcaseRVHub.MAUI.Stores;
using ShowcaseRVHub.MAUI.ViewModel;

namespace ShowcaseRVHub.MAUI.Commands
{
    public class OpenAddShowcaseUserCommand : CommandBase
    {
        private readonly ShowcaseUserStore _showcaseUserStore;
        private readonly NavigationModalStore _navigationModalStore;

        public OpenAddShowcaseUserCommand(ShowcaseUserStore showcaseUserStore, NavigationModalStore navigationStore)
        {
            _showcaseUserStore = showcaseUserStore;
            _navigationModalStore = navigationStore;
        }
        public override void Execute(object parameter)
        {
            AddShowcaseUserViewModel addShowcaseUserViewModel = new AddShowcaseUserViewModel(_showcaseUserStore, _navigationModalStore);
            _navigationModalStore.CurrentViewModel = addShowcaseUserViewModel;
        }
    }
}
