using MongoDB.Bson.Serialization.Attributes;

namespace MyWebApi.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Name")]
        public string BookName { get; set; } = null!;
        public decimal? Price { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Author { get; set; } = null!;
    }
}
