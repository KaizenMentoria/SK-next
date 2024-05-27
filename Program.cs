using Microsoft.EntityFrameworkCore;

namespace workspace;
using workspace.Data;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        // Npgsql
        var connectionString = builder.Configuration.GetConnectionString("NpgsqlDev");
        builder.Services.AddDbContext<SKDbContext>(options => options.UseNpgsql(connectionString));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        //if (!app.Environment.IsDevelopment())
        //{
        //    app.UseExceptionHandler("/Home/Error");
        //}
        app.UseStaticFiles();

        app.UseRouting();

        // app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
