using System.Text.Json.Serialization;

namespace Roadie.Gumroad
{
    public abstract class BaseGumroadResponse
    {
        [JsonPropertyName("success"), JsonInclude]
        public bool IsSuccess { get; internal set; }
    }
}
