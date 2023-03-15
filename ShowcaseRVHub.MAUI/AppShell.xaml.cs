using ShowcaseRVHub.MAUI.View;

namespace ShowcaseRVHub.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddUserPage), typeof(AddUserPage));
        }
    }
}