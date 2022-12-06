using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using RoleUserAppPolicy.Models;
using RoleUserAppPolicy.CustomAuthorization.Handler;
using RoleUserAppPolicy.CustomAuthorization.Requirement;
using RoleUserAppPolicy.CustomAuthorization;

var builder = WebApplication.CreateBuilder(args);
string conn = builder.Configuration.GetConnectionString("Conn");
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Login/GuestPage";
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CustomAuthorization", policy => policy.Requirements.Add(new CustomPolicyRequirement()));
});

builder.Services.AddSingleton<IAuthorizationHandler, CustomPolicyHandler>();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, CustomAuthorizationPolicyProvider>();
builder.Services.AddSingleton<IAuthorizationHandler, CustomPermissionHandler>();
builder.Services.AddDbContext<RoleUserAppContext>(options =>
{
    options.UseSqlServer(conn);
});
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
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
