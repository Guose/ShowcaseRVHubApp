using Microsoft.Extensions.Logging;
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