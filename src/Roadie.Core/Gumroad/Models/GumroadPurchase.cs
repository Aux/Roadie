using System.Text.Json.Serialization;

namespace Roadie.Gumroad
{
    public class GumroadPurchase
    {
        [JsonPropertyName("id"), JsonInclude]
        public string Id { get; set; }

        [JsonPropertyName("seller_id"), JsonInclude]
        public string SellerUserId { get; set; }

        [JsonPropertyName("product_id"), JsonInclude]
        public string ProductId { get; set; }

        [JsonPropertyName("product_name"), JsonInclude]
        public string ProductName { get; set; }

        [JsonPropertyName("product_permalink"), JsonInclude]
        public string ProductUrl { get; set; }

        [JsonPropertyName("sale_id"), JsonInclude]
        public string SaleId { get; set; }

        [JsonPropertyName("order_number"), JsonInclude]
        public int OrderNumber { get; set; }

        [JsonPropertyName("created_at"), JsonInclude]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("refunded"), JsonInclude]
        public bool IsRefunded { get; set; }

        [JsonPropertyName("disputed"), JsonInclude]
        public bool IsDisputed { get; set; }

        [JsonPropertyName("chargebacked"), JsonInclude]
        public bool IsChargebacked { get; set; }
    }
}
