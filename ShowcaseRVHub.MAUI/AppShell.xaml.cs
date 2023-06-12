namespace ShowcaseRVHub.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(RVNavigationView), typeof(RVNavigationView));
            Routing.RegisterRoute(nameof(RVChecklistView), typeof(RVChecklistView));
            Routing.RegisterRoute(nameof(ChecklistView), typeof(ChecklistView));
        }
    }
}