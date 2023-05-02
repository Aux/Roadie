using AspNet.Security.OAuth.Discord;
using Microsoft.AspNetCore.Authentication.Cookies;
using Roadie.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

builder.Services.AddAuthentication(options =>
{
    //options.RequireAuthenticatedSignIn = true;
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = DiscordAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.AccessDeniedPath = "/";
})
.AddDiscord(options =>
{
    options.ClientId = builder.Configuration["discord:client_id"];
    options.ClientSecret = builder.Configuration["discord:client_secret"];
    options.SaveTokens = true;
})
.AddGumroad(options =>
{
    options.ClientId = builder.Configuration["gumroad:client_id"]!;
    options.ClientSecret = builder.Configuration["gumroad:client_secret"];
    options.SaveTokens = true;

    options.Scope.Add("view_profile");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
