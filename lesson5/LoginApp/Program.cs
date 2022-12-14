using LoginApp.Models;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        string conn = builder.Configuration.GetConnectionString("Conn");

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<LoginAppContext>(options =>
        {
            options.UseSqlServer(conn);
        });
        builder.Services.AddSession();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseSession();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Login}/{id?}");

        app.Run();
    }
}