using ShowcaseRVHub.MAUI.Model;

namespace ShowcaseRVHub.MAUI.ViewModel
{
    [QueryProperty(nameof(User), "User")]
    public partial class RVNavigationViewModel : ViewModelBase
    {
        [ObservableProperty]
        UserModel user;
    }
}
