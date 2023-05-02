using Microsoft.AspNetCore.Authentication;

namespace Roadie.Authentication
{
    public static class GumroadAuthenticationExtensions
    {
        public static AuthenticationBuilder AddGumroad(
            this AuthenticationBuilder builder)
        {
            return builder.AddGumroad(GumroadAuthenticationDefaults.AuthenticationScheme, options => { });
        }

        public static AuthenticationBuilder AddGumroad(
            this AuthenticationBuilder builder,
            Action<GumroadAuthenticationOptions> configuration)
        {
            return builder.AddGumroad(GumroadAuthenticationDefaults.AuthenticationScheme, configuration);
        }

        public static AuthenticationBuilder AddGumroad(
            this AuthenticationBuilder builder,
            string scheme,
            Action<GumroadAuthenticationOptions> configuration)
        {
            return builder.AddGumroad(scheme, GumroadAuthenticationDefaults.AuthenticationScheme, configuration);
        }

        public static AuthenticationBuilder AddGumroad(
            this AuthenticationBuilder builder,
            string scheme,
            string caption,
            Action<GumroadAuthenticationOptions> configuration)
        {
            return builder.AddOAuth<GumroadAuthenticationOptions, GumroadAuthenticationHandler>(scheme, caption, configuration);
        }
    }
}
