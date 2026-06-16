using Core.UserInfo;
using Core.Users;
using Datalayer.Users;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// Session
builder.Services.AddSession();

builder.Services.AddScoped<
    IUserRepository,
    UserRepository>();

builder.Services.AddScoped<
    IUserService,
    UserService>();


builder.Services.AddScoped<
    IUserInfoService,
    UserInfoService>();

builder.Services.AddScoped<
    MacroCalculator>();

var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();