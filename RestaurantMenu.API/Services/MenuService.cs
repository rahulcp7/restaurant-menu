using MongoDB.Driver;
using RestaurantMenu.API.Models;

namespace RestaurantMenu.API.Services
{
    public class MenuService
    {
        private readonly IMongoCollection<MenuItem> _menuCollection;

        public MenuService(IConfiguration config)
        {
            var mongoClient = new MongoClient(config["MongoDB:ConnectionString"]);
            var database = mongoClient.GetDatabase(config["MongoDB:DatabaseName"]);
            _menuCollection = database.GetCollection<MenuItem>(config["MongoDB:MenuCollectionName"]);
        }

        public async Task<List<MenuItem>> GetAllAsync() =>
            await _menuCollection.Find(_=>true).ToListAsync();
            
        public async Task<MenuItem?> GetByIdAsync(string id) =>
            await _menuCollection.Find(x=> x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(MenuItem item) =>
            await _menuCollection.InsertOneAsync(item);    
        
    }
}