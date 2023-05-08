using System.Text.Json.Serialization;

namespace Roadie.Gumroad
{
    public class GumroadProductsResponse : BaseGumroadResponse
    {
        [JsonPropertyName("products"), JsonInclude]
        public IReadOnlyCollection<GumroadProduct> Products { get; internal set; }
    }
}
