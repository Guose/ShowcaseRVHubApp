using Microsoft.Extensions.Logging;
using ShowcaseRVHub.MAUI.Services.Interfaces;
using ShowcaseRVHub.MAUI.View;

namespace ShowcaseRVHub.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		    builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<IShowcaseUserDataService, ShowcaseUserDataService>();
            builder.Services.AddSingleton<IUserEmailService, UserEmailService>();
            builder.Services.AddSingleton<IUserRepository, UserRepository>();

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainView>();

            builder.Services.AddTransient<ShowcaseUserFormViewModel>();
            builder.Services.AddTransient<AddUserView>();

            builder.Services.AddTransient<ForgotPasswordViewModel>();
            builder.Services.AddTransient<ForgotPasswordView>();

            builder.Services.AddTransient<RVNavigationViewModel>();
            builder.Services.AddTransient<RVNavigationView>();

            return builder.Build();
        }        
    }
}