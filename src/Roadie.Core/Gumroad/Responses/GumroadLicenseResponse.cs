using System.Text.Json.Serialization;

namespace Roadie.Gumroad
{
    public class GumroadLicenseResponse : BaseGumroadResponse
    {
        [JsonPropertyName("purchase"), JsonInclude]
        public GumroadPurchase Purchase { get; internal set; }

        [JsonPropertyName("uses"), JsonInclude]
        public int UsageTotal { get; internal set; }
    }
}
