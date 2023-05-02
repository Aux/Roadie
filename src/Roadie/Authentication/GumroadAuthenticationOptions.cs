using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Security.Claims;

namespace Roadie.Authentication
{
    public class GumroadAuthenticationOptions : OAuthOptions
    {
        public GumroadAuthenticationOptions()
        {
            ClaimsIssuer = GumroadAuthenticationDefaults.Issuer;
            CallbackPath = GumroadAuthenticationDefaults.CallbackPath;
            AuthorizationEndpoint = GumroadAuthenticationDefaults.AuthorizationEndpoint;
            TokenEndpoint = GumroadAuthenticationDefaults.TokenEndpoint;
            UserInformationEndpoint = GumroadAuthenticationDefaults.UserInformationEndpoint;

            ClaimActions.MapJsonSubKey(ClaimTypes.NameIdentifier, "user", "user_id");
            ClaimActions.MapJsonSubKey(ClaimTypes.Name, "user", "name");
            ClaimActions.MapJsonSubKey(ClaimTypes.Email, "user", "email");

            Scope.Add("view_profile");
        }
    }
}
