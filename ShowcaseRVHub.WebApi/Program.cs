using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.Data.Repositories;
using ShowcaseRVHub.WebApi.Services;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // Add services to the container.
        builder.Services.AddDbContext<ShowcaseDbContext>(options =>
        {
            options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection"));
        });
        builder.Services.AddScoped<DbContextService>();

        builder.Services.AddScoped<IShowcaseUserRepo, ShowcaseUserRepo>();

        builder.Services.AddControllers();

        var app = builder.Build();

        using (var scope = app.Services.CreateAsyncScope())
        {
            DbContextService? dbService = scope.ServiceProvider.GetService<DbContextService>();
            await dbService!.MigrateDatabaseAsync();
        }

        // Configure the HTTP request pipeline.

        //app.UseHttpsRedirection();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.MapControllers();        

        await app.RunAsync();
    }
}
