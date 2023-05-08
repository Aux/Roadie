using Google.Cloud.Firestore;

namespace Roadie.Models
{
    [FirestoreData]
    public class RoadieGuild : BaseFirestoreModel
    {
        /// <summary>
        ///     The guild's unique Discord id number.
        /// </summary>
        [FirestoreProperty]
        public ulong Id { get; set; }

        /// <summary>
        ///     The guild's name.
        /// </summary>
        [FirestoreProperty]
        public string Name { get; set; }

        /// <summary>
        ///     The hash value associated with this guild's icon image url.
        /// </summary>
        [FirestoreProperty]
        public string IconHash { get; set; }
    }
}
