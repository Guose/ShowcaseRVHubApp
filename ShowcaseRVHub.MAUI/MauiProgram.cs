using Syncfusion.Maui.Core.Hosting;

namespace ShowcaseRVHub.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.ConfigureSyncfusionCore();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IShowcaseUserDataService, ShowcaseUserDataService>();
            builder.Services.AddSingleton<IUserEmailService, UserEmailService>();
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            builder.Services.AddSingleton<IRvService, RVService>();

            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<MainView>();

            builder.Services.AddTransient<ShowcaseUserFormViewModel>();
            builder.Services.AddTransient<AddUserView>();

            builder.Services.AddTransient<RVNavigationViewModel>();
            builder.Services.AddTransient<RVNavigationView>();

            builder.Services.AddTransient<RVChecklistViewModel>();
            builder.Services.AddTransient<RVChecklistView>();

            builder.Services.AddTransient<ChecklistViewModel>();
            builder.Services.AddTransient<ChecklistView>();

            return builder.Build();
        }        
    }
}