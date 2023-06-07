using Discord;
using Discord.Interactions;
using Discord.Rest;
using Google.Cloud.Functions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(FunctionsStartup))]

namespace Roadie.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void ConfigureServices(WebHostBuilderContext context, IServiceCollection services)
        {
            base.ConfigureServices(context, services);

            services.AddSingleton<DiscordRestClient>();
            services.AddSingleton(services =>
            {
                var discord = services.GetRequiredService<DiscordRestClient>();
                return new InteractionService(discord, new()
                {
                    DefaultRunMode = RunMode.Sync,
                    
                    LogLevel = LogSeverity.Verbose
                });
            });
        }
    }
}
