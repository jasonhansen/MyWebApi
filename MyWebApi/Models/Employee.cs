using MongoDB.Bson.Serialization.Attributes;

namespace MyWebApi.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Position { get; set; }

        public decimal Salary { get; set; }
    }
}
