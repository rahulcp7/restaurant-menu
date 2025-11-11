using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RestaurantMenu.API.Models
{
    public class MenuItem : BaseEntity
    {
        public string Name {get;set;} = string.Empty;
        public string Description {get;set;} = string.Empty;
        public decimal Price {get;set;}
        public string CategoryId {get;set;} = string.Empty;
    }
}