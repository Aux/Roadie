using Discord;
using Discord.Interactions;
using Discord.Rest;
using Discord.WebSocket;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Roadie.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services);

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

void ConfigureServices(IServiceCollection services)
{
    builder.Services.AddRazorPages();
    builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

    // Auth services

    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie("DiscordSession")
    .AddCookie("GumroadSession")
    .AddDiscord(options =>
    {
        builder.Configuration.GetSection("Discord").Bind(options);
        options.SignInScheme = "DiscordSession";
        options.SaveTokens = true;

        options.Scope.Add("identify");
        options.Scope.Add("guilds");
    })
    .AddGumroad(options =>
    {
        builder.Configuration.GetSection("Gumroad").Bind(options);
        options.SignInScheme = "GumroadSession";
        options.SaveTokens = true;

        options.Scope.Add("view_profile");
    });

    builder.Services.AddAuthorization(options =>
    {
        options.DefaultPolicy = new AuthorizationPolicyBuilder("Discord", "Gumroad")
            .RequireAuthenticatedUser()
            .Build();
    });

    // Discord services

    builder.Services.AddTransient<DiscordRestClient>();
    var discordSocketClient = new DiscordSocketClient(new()
    {
        AlwaysDownloadUsers = false,
        GatewayIntents = GatewayIntents.None,
        LogLevel = LogSeverity.Verbose,
        MessageCacheSize = 0,
        SuppressUnknownDispatchWarnings = true
    });
    builder.Services.AddSingleton(discordSocketClient);
    builder.Services.AddSingleton(new InteractionService(discordSocketClient, new()
    {
        LogLevel = LogSeverity.Verbose
    }));
}