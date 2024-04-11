using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mongodb.Repository.Entities
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("firstname")]
        public string? FirstName { get; set; }
        [BsonElement("lastname")]
        public string? LastName { get; set; }
        [BsonElement("age")]
        public int Age { get; set; }
        [BsonElement("hobbies")]
        public List<string>? Hobbies { get; set; }
    }
}
