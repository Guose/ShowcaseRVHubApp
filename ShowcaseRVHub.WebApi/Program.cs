using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data;
using ShowcaseRVHub.WebApi.Models;
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

        var app = builder.Build();

        using (var scope = app.Services.CreateAsyncScope())
        {
            DbContextService? dbService = scope.ServiceProvider.GetService<DbContextService>();
            await dbService!.MigrateDatabaseAsync();
        }

        // Configure the HTTP request pipeline.

        //app.UseHttpsRedirection();

        app.MapGet("api/users", async (ShowcaseDbContext context) =>
        {
            var users = await context.ShowcaseUsers.ToListAsync();

            return Results.Ok(users);
        });

        app.MapGet("api/user/{id}", async (ShowcaseDbContext context, Guid id) =>
        {
            var user = await context.ShowcaseUsers.Where(u => u.Id == id).FirstAsync().ConfigureAwait(false);

            return Results.Ok(user);
        });

        app.MapPost("api/users", async (ShowcaseDbContext context, ShowcaseUserModel user) =>
        {
            await context.ShowcaseUsers.AddAsync(user);

            await context.SaveChangesAsync();

            return Results.Created($"api/users/{user.Id}", user);
        });

        app.MapPut("api/users/{id}", async (ShowcaseDbContext context, Guid id, ShowcaseUserModel user) =>
        {
            var userModel = await context.ShowcaseUsers.FirstOrDefaultAsync(u => u.Id == id);

            if (userModel == null)
            {
                return Results.NotFound();
            }

            userModel.FirstName = string.IsNullOrEmpty(user.FirstName) ? userModel.FirstName: user.FirstName;
            userModel.LastName = string.IsNullOrEmpty(user.LastName) ? userModel.LastName : user.LastName;
            userModel.Email = string.IsNullOrEmpty(user.Email) ? userModel.Email : user.Email;
            userModel.Phone = string.IsNullOrEmpty(user.Phone) ? userModel.Phone : user.Phone;
            userModel.Username = string.IsNullOrEmpty(user.Username) ? userModel.Username : user.Username;
            userModel.Password = string.IsNullOrEmpty(user.Password) ? userModel.Password : user.Password;
            userModel.ModifiedOn = DateTime.UtcNow;
            userModel.IsRemembered = user.IsRemembered;

            await context.SaveChangesAsync();

            return Results.NoContent();
        });

        app.MapDelete("api/users/{id}", async (ShowcaseDbContext context, Guid id) =>
        {
            var deleteUser = await context.ShowcaseUsers.FirstOrDefaultAsync(u => u.Id == id);

            if (deleteUser == null)
            {
                return Results.NotFound();
            }

            context.ShowcaseUsers.Remove(deleteUser);

            await context.SaveChangesAsync();

            return Results.NoContent();
        });

        await app.RunAsync();
    }
}
