using System.Text.Json.Serialization;

namespace Roadie.Gumroad
{
    public class GumroadCouponResponse : BaseGumroadResponse
    {
        [JsonPropertyName("offer_code"), JsonInclude]
        public GumroadCoupon Coupon { get; internal set; }
    }
}
