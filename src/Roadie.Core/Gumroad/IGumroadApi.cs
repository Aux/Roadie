using RestEase;

namespace Roadie.Gumroad
{
    [Header("User-Agent", "Roadie (https://github.com/Aux/Roadie)")]
    [SerializationMethods(Body = BodySerializationMethod.UrlEncoded)]
    public interface IGumroadApi
    {
        [Get("user")]
        Task<GumroadUserResponse> GetUserAsync(
            [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> data,
            CancellationToken cancelToken);

        [Get("products")]
        Task<GumroadProductsResponse> GetProductsAsync(
            [Body(BodySerializationMethod.UrlEncoded)]IDictionary<string, object> data, 
            CancellationToken cancelToken);

        [Get("products/{productId}")]
        Task<GumroadProductResponse> GetProductAsync(
            [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> data, 
            [Path] string productId, 
            CancellationToken cancelToken);

        [Get("products/{productId}/offer_codes")]
        Task<GumroadCouponsResponse> GetCouponsAsync(
            [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> data,
            [Path] string productId,
            CancellationToken cancelToken);

        [Get("products/{productId}/offer_codes/{offerCodeId}")]
        Task<GumroadCouponResponse> GetCouponAsync(
            [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> data,
            [Path] string productId,
            [Path] string offerCodeId,
            CancellationToken cancelToken);

        [Post("products/{productId}/offer_codes")]
        Task<GumroadCouponResponse> PostCouponAsync(
            [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> data,
            [Path] string productId,
            CancellationToken cancelToken);

        [Post("licenses/verify")]
        Task<GumroadLicenseResponse> PostLicenseAsync(
            [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> data,
            CancellationToken cancelToken);
    }
}
