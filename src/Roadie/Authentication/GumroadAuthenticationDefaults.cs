namespace Roadie.Authentication
{
    public static class GumroadAuthenticationDefaults
    {
        /// <summary>
        /// Default value for <see cref="AuthenticationScheme.Name"/>.
        /// </summary>
        public const string AuthenticationScheme = "Gumroad";

        /// <summary>
        /// Default value for <see cref="AuthenticationScheme.DisplayName"/>.
        /// </summary>
        public static readonly string DisplayName = "Gumroad";

        /// <summary>
        /// Default value for <see cref="AuthenticationSchemeOptions.ClaimsIssuer"/>.
        /// </summary>
        public static readonly string Issuer = "Gumroad";

        /// <summary>
        /// Default value for <see cref="RemoteAuthenticationOptions.CallbackPath"/>.
        /// </summary>
        public static readonly string CallbackPath = "/signin-gumroad";

        /// <summary>
        /// Default value for <see cref="OAuthOptions.AuthorizationEndpoint"/>.
        /// </summary>
        public static readonly string AuthorizationEndpoint = "https://gumroad.com/oauth/authorize";

        /// <summary>
        /// Default value for <see cref="OAuthOptions.TokenEndpoint"/>.
        /// </summary>
        public static readonly string TokenEndpoint = "https://api.gumroad.com/oauth/token";

        /// <summary>
        /// Default value for <see cref="OAuthOptions.UserInformationEndpoint"/>.
        /// </summary>
        public static readonly string UserInformationEndpoint = "https://api.gumroad.com/v2/user";
    }
}
