using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Web_Blog.Models;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình DbContext với chuỗi kết nối từ appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Cấu hình Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; 
})
.AddGoogle(options =>
{
    options.ClientId = "1025894182502-1jcc5t7bbvtq12do49cdfjpl4tj6e5se.apps.googleusercontent.com";
    options.ClientSecret = "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";
    options.CorrelationCookie.SameSite = SameSiteMode.None;
    options.CorrelationCookie.SecurePolicy = CookieSecurePolicy.Always;
});

// Thêm dịch vụ logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Thêm session vào services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian hết hạn của session
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; // Cần thiết cho session
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    Console.WriteLine($"Request Path: {context.Request.Path}");
    Console.WriteLine($"Request Method: {context.Request.Method}");
    Console.WriteLine($"Request Headers: {context.Request.Headers}");

    await next.Invoke();

    Console.WriteLine($"Response Status Code: {context.Response.StatusCode}");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Sử dụng session
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
