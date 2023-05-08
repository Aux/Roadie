using System.Text.Json.Serialization;

namespace Roadie.Gumroad
{
    // Partial model since gumroad sends a LOT of unnecessary garbage
    public class GumroadProduct
    {
        [JsonPropertyName("id"), JsonInclude]
        public string Id { get; set; }

        [JsonPropertyName("name"), JsonInclude]
        public string Name { get; set; }

        [JsonPropertyName("custom_summary"), JsonInclude]
        public string Summary { get; set; }

        [JsonPropertyName("url"), JsonInclude]
        public string Url { get; set; }

        [JsonPropertyName("short_url"), JsonInclude]
        public string ShortUrl { get; set; }

        [JsonPropertyName("preview_url"), JsonInclude]
        public string PreviewImageUrl { get; set; }

        [JsonPropertyName("thumbnail_url"), JsonInclude]
        public string ThumbnailImageUrl { get; set; }

        [JsonPropertyName("custom_permalink"), JsonInclude]
        public string PermalinkText { get; set; }

        [JsonPropertyName("tags"), JsonInclude]
        public IReadOnlyCollection<string> Tags { get; set; }

        [JsonPropertyName("published"), JsonInclude]
        public bool IsPublished { get; set; }

        [JsonPropertyName("shown_on_profile"), JsonInclude]
        public bool IsVisible { get; set; }

        [JsonPropertyName("deleted"), JsonInclude]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("is_tiered_membership"), JsonInclude]
        public bool IsTieredMembership { get; set; }
    }
}
