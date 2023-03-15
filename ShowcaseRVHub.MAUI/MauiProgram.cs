using Microsoft.Extensions.Logging;
using ShowcaseRVHub.Domain.Queries;
using ShowcaseRVHub.MAUI.Stores;
using ShowcaseRVHub.MAUI.View;
using ShowcaseRVHub.MAUI.ViewModel;

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

            builder.Services.AddSingleton<NavigationModalStore>();
            builder.Services.AddSingleton<ShowcaseUserStore>();

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddTransient<ShowcaseUserFormViewModel>();
            builder.Services.AddTransient<AddUserPage>();

            return builder.Build();
        }
    }
}