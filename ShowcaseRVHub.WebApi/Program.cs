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

        await app.RunAsync();
    }
}
