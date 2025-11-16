using MongoDB.Driver;
using RestaurantMenu.Data.Entities;

namespace RestaurantMenu.Data.Repositories
{
    public class MenuRepository: MongoRepository<MenuItem>
    {
        public MenuRepository(IMongoDatabase database): base(database, "MenuItems")
        {

        }
        //add menu specific queries later
    }
}