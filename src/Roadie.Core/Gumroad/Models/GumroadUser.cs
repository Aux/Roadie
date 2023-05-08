using System.Text.Json.Serialization;

namespace Roadie.Gumroad
{
    public class GumroadUser
    {
        [JsonPropertyName("user_id"), JsonInclude]
        public string Id { get; internal set; }

        [JsonPropertyName("name"), JsonInclude]
        public string Name { get; internal set; }

        [JsonPropertyName("display_name"), JsonInclude]
        public string DisplayName { get; internal set; }

        [JsonPropertyName("bio"), JsonInclude]
        public string Description { get; internal set; }

        [JsonPropertyName("url"), JsonInclude]
        public string Url { get; internal set; }

        [JsonPropertyName("profile_url"), JsonInclude]
        public string ProfileImageUrl { get; internal set; }
    }
}
