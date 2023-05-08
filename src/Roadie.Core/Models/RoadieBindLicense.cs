using Google.Cloud.Firestore;

namespace Roadie.Models
{
    /// <summary>
    ///     Gumroad license binding information, ensures a single license can't be used by multiple users.
    /// </summary>
    [FirestoreData]
    public class RoadieBindLicense : BaseFirestoreModel
    {
        /// <summary>
        ///     The user's unique Discord id number.
        /// </summary>
        [FirestoreProperty]
        public ulong DiscordUserId { get; set; }

        /// <summary>
        ///     The Discord role id assocaited with this binding.
        /// </summary>
        [FirestoreProperty]
        public ulong DiscordRoleId { get; set; }

        /// <summary>
        ///     The gumroad license value associated with this binding.
        /// </summary>
        [FirestoreProperty]
        public string License { get; set; }
    }
}
