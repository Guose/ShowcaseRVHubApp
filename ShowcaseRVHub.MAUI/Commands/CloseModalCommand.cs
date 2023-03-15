using ShowcaseRVHub.MAUI.Stores;

namespace ShowcaseRVHub.MAUI.Commands
{
    public class CloseModalCommand : CommandBase
    {
        private readonly NavigationModalStore _navigationStore;

        public CloseModalCommand(NavigationModalStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.Close();
        }
    }
}
