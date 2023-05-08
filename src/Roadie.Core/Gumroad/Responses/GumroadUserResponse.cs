using System.Text.Json.Serialization;

namespace Roadie.Gumroad
{
    public class GumroadUserResponse : BaseGumroadResponse
    {
        [JsonPropertyName("user"), JsonInclude]
        public GumroadUser User { get; internal set; }
    }
}
