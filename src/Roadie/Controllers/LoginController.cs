using AspNet.Security.OAuth.Discord;
using Microsoft.AspNetCore.Mvc;
using Roadie.Authentication;

namespace Roadie.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        [HttpGet("discord")]
        public IActionResult Discord()
        {
            if (User.Identity.IsAuthenticated) return RedirectToPagePermanentPreserveMethod("/dashboard");
            return Challenge(DiscordAuthenticationDefaults.AuthenticationScheme);
        }

        [HttpGet("gumroad")]
        public IActionResult Gumroad(string returnUrl = "/")
        {
            if (User.Identity.IsAuthenticated) return Redirect(returnUrl);
            return Challenge(GumroadAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
