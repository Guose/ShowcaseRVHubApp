using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using ShowcaseRVHub.WebApi.Data;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.Data.Repositories;
using ShowcaseRVHub.WebApi.Extensions;
using System.Diagnostics;

internal class Program
{
    private const string clientPath = @"C:\Users\Guose\source\repos\GitHubRepos\ShowcaseRVHubApp\ShowcaseRVHub.React\rv-email-service";
    private const string serverPath = @"C:\Users\Guose\source\repos\GitHubRepos\ShowcaseRVHubApp\ShowcaseRVHub.React\server";
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddScoped<IUserRepo, UserRepo>();
        builder.Services.AddScoped<IRVRepo, RVRepo>();
        
        // Add DbContext to the services to the container.
        builder.Services.AddDbContext<ShowcaseDbContext>(options =>
        {
            options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection"));
        });


        builder.Services.AddControllers().AddNewtonsoftJson(s =>
        {
            s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
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

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        // Start the React client and Express.js server as child processes
        var clientAppProcess = StartClientAppProcess(clientPath);
        var serverAppProcess = StartExpressServerProcess(serverPath);

        await app.RunAsync();

        // Stop the React client and Express.js server processes
        clientAppProcess.CloseMainWindow();
        serverAppProcess.CloseMainWindow();
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
