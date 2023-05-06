using Discord;
using Discord.Rest;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Roadie.Pages
{
    [Authorize]
    [Route("dashboard")]
    public class DashboardModel : PageModel
    {
        private readonly ILogger _logger;

        public RestSelfUser DiscordUser { get; set; }
        public IEnumerable<RestUserGuild> DiscordGuilds { get; set; }

        public DashboardModel(ILogger<DashboardModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            var discordToken = await HttpContext.GetTokenAsync("Discord", "access_token");
            var gumroadToken = await HttpContext.GetTokenAsync("Gumroad", "access_token");

            var discord = new DiscordRestClient();
            await discord.LoginAsync(TokenType.Bearer, discordToken);

            DiscordUser = discord.CurrentUser;

            var allguilds = await discord.GetGuildSummariesAsync().FlattenAsync();
            DiscordGuilds = allguilds.Where(x => x.Permissions.ManageGuild == true);
        }
    }
}
