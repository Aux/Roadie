using System.Text.Json.Serialization;

namespace Roadie.Gumroad
{
    public class GumroadProductResponse : BaseGumroadResponse
    {
        [JsonPropertyName("product"), JsonInclude]
        public GumroadProduct Product { get; internal set; }
    }
}
