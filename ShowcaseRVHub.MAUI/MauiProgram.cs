using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShowcaseRVHub.EntityFramework;
using ShowcaseRVHub.MAUI.Stores;
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

            string connectionString = builder.Configuration.GetConnectionString("SQLiteConnection");
            var options = new DbContextOptionsBuilder().UseSqlite(connectionString).Options;

            using (var context = new ShowcaseUsersDbContext(options))
            {
                context.Database.EnsureCreated();
            }

            builder.Services.AddSingleton<ShowcaseUsersDbContextFactory>();

            builder.Services.AddSingleton<NavigationModalStore>();
            builder.Services.AddSingleton<ShowcaseUserStore>();

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