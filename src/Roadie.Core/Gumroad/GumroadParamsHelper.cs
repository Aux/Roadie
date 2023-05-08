namespace Roadie.Gumroad
{
    public static class GumroadParamsHelper
    {

        public static IDictionary<string, object> MakeAccessTokenParam(string accessToken)
        {
            return new Dictionary<string, object>
            {
                { "access_token", accessToken }
            };
        }

        public static IDictionary<string, object> MakePostCouponParams(string accessToken, string name, int amountOff, bool isPercent = true)
        {
            return new Dictionary<string, object>
            {
                { "access_token", accessToken },
                { "name", name },
                { "amount_off", amountOff },
                { "max_purchase_count", 1 },
                { "offer_type", isPercent ? "percent" : "cents" }
            };
        }
    }
}
