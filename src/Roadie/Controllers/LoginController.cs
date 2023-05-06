using AspNet.Security.OAuth.Discord;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Roadie.Authentication;

namespace Roadie.Controllers
{
    [AllowAnonymous]
    [Route("login")]
    public class LoginController : Controller
    {
        [HttpGet("discord")]
        public IActionResult LoginDiscord(string returnUrl = "/dashboard")
        {
            return Challenge(new AuthenticationProperties
            {
                RedirectUri = returnUrl
            }, DiscordAuthenticationDefaults.AuthenticationScheme);
        }

        [HttpGet("gumroad")]
        public IActionResult LoginGumroad(string returnUrl = "/dashboard")
        {
            return Challenge(new AuthenticationProperties
            {
                RedirectUri = returnUrl
            }, GumroadAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
