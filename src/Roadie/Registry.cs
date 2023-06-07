using Discord;
using Discord.Interactions;
using Discord.Rest;
using Discord.WebSocket;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using RestEase.HttpClientFactory;
using Roadie.Authentication;
using Roadie.Gumroad;
using Roadie.Services;

namespace Roadie
{
    public static class Registry
    {
        public static void AddAuthentication(this WebApplicationBuilder builder)
        {
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
        }

        public static void AddDiscord(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<DiscordRestClient>();
            builder.Services.AddSingleton(_ => new DiscordSocketClient(new()
            {
                AlwaysDownloadUsers = false,
                GatewayIntents = GatewayIntents.None,
                LogLevel = LogSeverity.Verbose,
                MessageCacheSize = 0,
                SuppressUnknownDispatchWarnings = true
            }));
            builder.Services.AddSingleton(services =>
            {
                var discord = services.GetRequiredService<DiscordSocketClient>();
                return new InteractionService(discord, new()
                {
                    LogLevel = LogSeverity.Verbose
                });
            });

            builder.Services.AddHostedService<DiscordStartupService>();
            builder.Services.AddHostedService<InteractionHandlingService>();
        }

        public static void AddGumroad(this WebApplicationBuilder builder)
        {
            builder.Services.AddRestEaseClient<IGumroadApi>(GumroadConstants.ApiUrl, new()
            {
                RestClientConfigurer = client => client.ResponseDeserializer = new Gumroad.JsonResponseDeserializer()
            });
        }

        public static void AddFirestore(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton(_ => FirestoreDb.Create(builder.Configuration["Firestore:ProjectId"]));
        }
    }
}
