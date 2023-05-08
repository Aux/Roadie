using System.Text.Json.Serialization;

namespace Roadie.Gumroad
{
    public class GumroadCouponsResponse : BaseGumroadResponse
    {
        [JsonPropertyName("offer_codes"), JsonInclude]
        public IReadOnlyCollection<GumroadCoupon> Coupons { get; internal set; }
    }
}
