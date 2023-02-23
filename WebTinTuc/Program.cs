using Data.SqlServer.Context;
using Data.SqlServer.Data;
using Infrastructure.IoC;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#region    Cấu hình DataContext
//Nạp pendency vao project
DependencyContainer.RegisterIoC(builder.Services, builder.Configuration);

//Kết nối sever database context cùng với Auth + Identity + Token
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "MenuMain",
    pattern: "MenuMain",
    new
    {
        controller = "MenuMain",
        action = "Index"
    });
app.MapControllerRoute(
    name: "MenuMain",
    pattern: "MenuMainCreate",
    new
    {
        controller = "MenuMain",
        action = "Create"
    });
app.MapControllerRoute(
    name: "MenuMain",
    pattern: "MenuMainEdit",
    new
    {
        controller = "MenuMain",
        action = "Edit"
    });
app.MapControllerRoute(
    name: "TheLoai",
    pattern:"TheLoai",
    new {controller="TheLoai",action="Index"
    });
app.MapControllerRoute(
    name: "TheLoai",
    pattern: "TheLoaiCreate",
    new {controller = "TheLoai",action = "Create"
    });
app.MapControllerRoute(
    name: "TheLoai",
    pattern: "TheLoaiEdit",
    new
    {
        controller = "TheLoai",
        action = "Edit"
    });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TheLoai}/{action=Index}/{id?}");

app.Run();
