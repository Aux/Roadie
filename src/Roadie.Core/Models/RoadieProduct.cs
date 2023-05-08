using Google.Cloud.Firestore;

namespace Roadie.Models
{
    /// <summary>
    ///     Gumroad product identity and configuration.
    /// </summary>
    [FirestoreData]
    public class RoadieProduct : BaseFirestoreModel
    {
        /// <summary>
        ///     The product's unique Gumroad id string.
        /// </summary>
        [FirestoreProperty]
        public string GumroadProductId { get; set; }

        /// <summary>
        ///     The user id of the seller on Gumroad.
        /// </summary>
        [FirestoreProperty]
        public string GumroadSellerId { get; set; }

        /// <summary>
        ///     The custom permalink value for this product, if specified.
        /// </summary>
        [FirestoreProperty]
        public string PermalinkText { get; set; }

        /// <summary>
        ///     Should verified purchasers of this product be allowed to set up verification roles in their own server.
        /// </summary>
        [FirestoreProperty]
        public bool AllowCrossServerRoles { get; set; }
    }
}
