using ShowcaseRVHub.MAUI.View;

namespace ShowcaseRVHub.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(RVNavigationView), typeof(RVNavigationView));
        }
    }
}