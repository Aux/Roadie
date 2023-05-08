using Google.Cloud.Firestore;

namespace Roadie.Models
{
    /// <summary>
    ///     Internal user identity and configuration.
    /// </summary>
    [FirestoreData]
    public class RoadieUser : BaseFirestoreModel
    {
        /// <summary>
        ///     The user's unique Discord id number.
        /// </summary>
        [FirestoreProperty]
        public ulong DiscordUserId { get; set; }

        /// <summary>
        ///     The hash value associated with this user's avatar image url.
        /// </summary>
        [FirestoreProperty]
        public string DiscordUserAvatarHash { get; set; }

        /// <summary>
        ///     The user's unique Gumroad id string.
        /// </summary>
        [FirestoreProperty]
        public string GumroadUserId { get; set; }

        /// <summary>
        ///     Should configured products default to allowing cross server verification.
        /// </summary>
        [FirestoreProperty]
        public bool GlobalAllowCrossServerRoles { get; set; } = false;
    }
}
