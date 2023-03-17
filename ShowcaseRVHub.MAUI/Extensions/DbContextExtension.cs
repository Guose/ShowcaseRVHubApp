using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ShowcaseRVHub.EntityFramework;

namespace ShowcaseRVHub.MAUI.Extensions
{
    public static class DbContextExtension
    {
        public static IHostBuilder AddDbContextExtension(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                string connectionString = context.Configuration.GetConnectionString("SQLiteConnection");

                services.AddSingleton<DbContextOptions>(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
                services.AddSingleton<ShowcaseUsersDbContextFactory>();

            });

            return hostBuilder;
        }
    }
}
