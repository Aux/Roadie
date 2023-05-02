using AspNet.Security.OAuth.Discord;
using Discord.Rest;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Roadie.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public RestSelfUser DiscordUser { get; set; } = null;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            if (!User.Identity.IsAuthenticated) return;

            var token = await HttpContext.GetTokenAsync(DiscordAuthenticationDefaults.AuthenticationScheme, "access_token");

            var discord = new DiscordRestClient();
            await discord.LoginAsync(Discord.TokenType.Bearer, token);
            DiscordUser = discord.CurrentUser;
        }
    }
}