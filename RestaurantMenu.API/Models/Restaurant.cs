using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RestaurantMenu.API.Models
{
    public class Restaurant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id {get;set;}

        public string Name {get;set;} = string.Empty;
        public string Location {get;set;} = string.Empty;
        public List<MenuItem> MenuItems {get;set;} = new();
    }
}