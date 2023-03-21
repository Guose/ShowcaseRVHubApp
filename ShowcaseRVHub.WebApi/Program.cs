using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data;
using ShowcaseRVHub.WebApi.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<ShowcaseDbContext>(options =>
        {
            options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection"));
        });

        using IServiceScope scope = builder.Services.BuildServiceProvider().CreateScope();

        ShowcaseDbContext? dbContext = scope.ServiceProvider.GetService<ShowcaseDbContext>();
        dbContext!.Database.Migrate();

        var app = builder.Build();
        // Configure the HTTP request pipeline.

        //app.UseHttpsRedirection();

        app.MapGet("api/users", async (ShowcaseDbContext context) =>
        {
            var users = await context.ShowcaseUsers.ToListAsync();

            return Results.Ok(users);
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

            userModel.FirstName = user.FirstName ?? userModel.FirstName;
            userModel.LastName = user.LastName ?? userModel.LastName;
            userModel.Email = user.Email ?? userModel.Email;
            userModel.Phone = user.Phone ?? userModel.Phone;
            userModel.Username = user.Username ?? userModel.Username;
            userModel.Password = user.Password ?? userModel.Password;
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

        app.Run();
    }
}
