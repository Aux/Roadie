using Discord;
using Discord.Rest;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Roadie.Gumroad;

namespace Roadie.Pages
{
    [Authorize]
    [Route("dashboard")]
    public class DashboardModel : PageModel
    {
        private readonly ILogger _logger;
        private readonly DiscordRestClient _discord;
        private readonly IGumroadApi _gumroad;

        public RestSelfUser DiscordUser { get; set; }
        public IEnumerable<RestUserGuild> DiscordGuilds { get; set; }
        public GumroadUser GumroadUser { get; set; }
        public IEnumerable<GumroadProduct> GumroadProducts { get; set; }

        public DashboardModel(ILogger<DashboardModel> logger, DiscordRestClient discord, IGumroadApi gumroad)
        {
            _logger = logger;
            _discord = discord;
            _gumroad = gumroad;
        }

        public async Task OnGetAsync()
        {
            var discordToken = await HttpContext.GetTokenAsync("Discord", "access_token");

            await _discord.LoginAsync(TokenType.Bearer, discordToken);
            var allguilds = await _discord.GetGuildSummariesAsync().FlattenAsync();

            DiscordUser = _discord.CurrentUser;
            DiscordGuilds = allguilds;

            var gumroadToken = await HttpContext.GetTokenAsync("Gumroad", "access_token");

            var tokenParams = GumroadParamsHelper.MakeAccessTokenParam(gumroadToken);
            var userResponse =  await _gumroad.GetUserAsync(tokenParams, HttpContext.RequestAborted);
            var productsResponse = await _gumroad.GetProductsAsync(tokenParams, HttpContext.RequestAborted);

            GumroadUser = userResponse.User;
            GumroadProducts = productsResponse.Products;
        }
    }
}
