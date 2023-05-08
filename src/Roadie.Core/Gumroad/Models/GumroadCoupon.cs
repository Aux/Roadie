using System.Text.Json.Serialization;

namespace Roadie.Gumroad
{
    public class GumroadCoupon
    {
        [JsonPropertyName("id"), JsonInclude]
        public string Id { get; internal set; }

        [JsonPropertyName("name"), JsonInclude]
        public string Name { get; internal set; }

        [JsonPropertyName("amount_cents"), JsonInclude]
        public int AmountCents { get; internal set; }

        [JsonPropertyName("max_purchase_count"), JsonInclude]
        public int? MaxPurchaseCount { get; internal set; }

        [JsonPropertyName("universal"), JsonInclude]
        public bool IsUniversal { get; internal set; }

        [JsonPropertyName("usage_total"), JsonInclude]
        public int UsageTotal { get; internal set; }
    }
}
