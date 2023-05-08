using Google.Cloud.Firestore;

namespace Roadie.Models
{
    public abstract class BaseFirestoreModel
    {
        [FirestoreDocumentId]
        public DocumentReference Reference { get; set; }

        [FirestoreDocumentCreateTimestamp]
        public DateTime CreatedAt { get; set; }

        [FirestoreDocumentUpdateTimestamp]
        public DateTime UpdatedAt { get; set; }
    }
}
