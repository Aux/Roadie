using Discord;
using Discord.Interactions;

namespace Roadie.Commands
{
    [Group("roadie", "Roadie's personal information commands.")]
    public class RoadieModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("about", "Get information about this bot application.")]
        public async Task AboutAsync()
        {
            var app = await Context.Client.GetApplicationInfoAsync();

            var embed = new EmbedBuilder()
                .WithTitle(app.Name)
                .WithDescription(app.Description)
                .AddField("Source", "https://github.com/Aux/Roadie")
                .WithFooter($"by {app.Owner} ({app.Owner.Id})")
                .Build();

            await RespondAsync(embed: embed, ephemeral: true);
        }
    }
}
