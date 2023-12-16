using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using ShowcaseRVHub.WebApi.Data;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.Data.Repositories;
using System.Diagnostics;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var configuration = new ConfigurationBuilder()
            .SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        builder.WebHost.UseUrls("http://*:5000");
        
        builder.Services.AddScoped<IUserRepo, UserRepo>();
        builder.Services.AddScoped<IRVRepo, RVRepo>();
        builder.Services.AddScoped<IRentalRepo, RentalRepo>();
        builder.Services.AddScoped<IRenterRepo,  RenterRepo>();
        builder.Services.AddScoped<IArrivalRepo, ArrivalRepo>();
        builder.Services.AddScoped<IDepartureRepo, DepartureRepo>();
        builder.Services.AddScoped<IMaintenance, MaintenanceRepo>();

        var connectionString = configuration.GetConnectionString("SQLServerLocalhostConnection");
        //var connectionString = configuration.GetConnectionString("SQLServerConnection");

        // Add DbContext to the services to the container.
        builder.Services.AddDbContext<ShowcaseDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
            //options.EnableSensitiveDataLogging();
        });

        // Logging
        builder.Logging.AddConsole(); // Add console logging
        var logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();

        // Log the connection string
        logger.LogInformation($"Using connection string: {connectionString}");

        builder.Services.AddControllers().AddNewtonsoftJson(s =>
        {
            s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            s.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

        }).AddJsonOptions(opt =>
        {
            opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        });
                
        builder.Services.AddEndpointsApiExplorer();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseCors(options =>
        {
            options
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllers();

        await app.RunAsync();
    }

    private static Process StartClientAppProcess(string clientAppDirectory)
    {
        var clientAppProcess = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c npm start",
                UseShellExecute = false,
                WorkingDirectory = clientAppDirectory,
                CreateNoWindow = true,
            }
        };

        clientAppProcess.Start();

        return clientAppProcess;
    }

    private static Process StartExpressServerProcess(string expressServerDirectory)
    {
        var expressServerProcess = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c npm run dev",
                UseShellExecute = false,
                WorkingDirectory = expressServerDirectory,
                CreateNoWindow = true,
            }
        };

        expressServerProcess.Start();

        return expressServerProcess;
    }
}
