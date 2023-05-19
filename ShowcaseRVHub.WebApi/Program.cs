using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using ShowcaseRVHub.WebApi.Data;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.Data.Repositories;
using ShowcaseRVHub.WebApi.Services;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddScoped<IUserRepo, UserRepo>();
        builder.Services.AddScoped<IRVRepo, RVRepo>();
        
        // Add services to the container.
        builder.Services.AddDbContext<ShowcaseDbContext>(options =>
        {
            options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection"));
            //options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection"));
        });
        //builder.Services.AddScoped<DbContextService>();


        builder.Services.AddControllers().AddNewtonsoftJson(s =>
        {
            s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        });
                
        builder.Services.AddEndpointsApiExplorer();
        var app = builder.Build();

        //using (var scope = app.Services.CreateAsyncScope())
        //{
        //    DbContextService? dbService = scope.ServiceProvider.GetService<DbContextService>();
        //    await dbService!.MigrateDatabaseAsync();
        //}

        // Configure the HTTP request pipeline.


        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        //app.UseRouting();

        //app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();        

        await app.RunAsync();
    }
}
