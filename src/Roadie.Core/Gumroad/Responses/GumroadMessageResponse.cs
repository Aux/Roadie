using System.Text.Json.Serialization;

namespace Roadie.Gumroad
{
    public class GumroadMessageResponse : BaseGumroadResponse
    {
        [JsonPropertyName("message"), JsonInclude]
        public string Message { get; internal set; }
    }
}
