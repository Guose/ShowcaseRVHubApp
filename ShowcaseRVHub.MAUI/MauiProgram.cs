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
            builder.Services.AddSingleton<IRenterDataService, RenterDataService>();
            builder.Services.AddSingleton<IRvDataService, RvDataService>();
            builder.Services.AddSingleton<IRentalDataService, RentalDataService>();

            builder.Services.AddTransient<IUserEmailService, UserEmailService>();
            builder.Services.AddTransient<IUserDataServiceHelper, UserDataServiceHelper>();
            builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();

            builder.Services.AddTransient<CalendarBehaviorHelper>();

            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<MainView>();
            builder.Services.AddTransient<ShowcaseUserFormViewModel>();
            builder.Services.AddTransient<AddUserView>();
            builder.Services.AddTransient<RVNavigationViewModel>();
            builder.Services.AddTransient<RVNavigationView>();
            builder.Services.AddTransient<RentalCheckOutViewModel>();
            builder.Services.AddTransient<RentalCheckOutView>();
            builder.Services.AddTransient<ChecklistViewModel>();
            builder.Services.AddTransient<ChecklistView>();

            return builder.Build();
        }        
    }
}