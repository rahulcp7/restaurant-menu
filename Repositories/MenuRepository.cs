using MongoDB.Driver;
using RestaurantMenu.API.Models;

namespace RestaurantMenu.API.Repositories
{
    public class MenuRepository: MongoRepository<MenuItem>
    {
        public MenuRepository(IMongoDatabase database): base(database, "MenuItems")
        {

        }
        //add menu specific queries later
    }
}