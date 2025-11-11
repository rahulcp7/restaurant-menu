using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RestaurantMenu.API.Models
{
    public abstract class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get;set;} = string.Empty;
    }
}