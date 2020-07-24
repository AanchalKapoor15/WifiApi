using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WifiApi.Models
{
    public class Wifi
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        public string Location { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}