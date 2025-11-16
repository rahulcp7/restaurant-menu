using MongoDB.Driver;
using RestaurantMenu.Data.Entities;   
using RestaurantMenu.Data.Repositories;   



namespace RestaurantMenu.Business.Services
{
    public class MenuService : IMenuService
    {
        // private readonly IMongoCollection<MenuItem> _menuCollection;
        private readonly IRepository<MenuItem> _menuRepositiry;

        // public MenuService(IConfiguration config)
        // {
        //     var mongoClient = new MongoClient(config["MongoDB:ConnectionString"]);
        //     var database = mongoClient.GetDatabase(config["MongoDB:DatabaseName"]);
        //     _menuCollection = database.GetCollection<MenuItem>(config["MongoDB:MenuCollectionName"]);
        // }

        public MenuService(IRepository<MenuItem> MenuRepository)
        {
            _menuRepositiry=MenuRepository;
        }

        // public async Task<List<MenuItem>> GetAllAsync() =>
        //     await _menuCollection.Find(_=>true).ToListAsync();
            
        // public async Task<MenuItem?> GetByIdAsync(string id) =>
        //     await _menuCollection.Find(x=> x.Id == id).FirstOrDefaultAsync();

        // public async Task CreateAsync(MenuItem item) =>
        //     await _menuCollection.InsertOneAsync(item);    

        public Task<List<MenuItem>> GetAllAsync()=> _menuRepositiry.GetAllAsync();
        public Task<MenuItem?> GetByIdAsync(string id) =>_menuRepositiry.GetByIdAsync(id);
        public Task CreateAsync(MenuItem item) => _menuRepositiry.CreateAsync(item);
        public Task UpdateAsync(string id, MenuItem item)=> _menuRepositiry.UpdateAsync(id,item);
        public Task DeleteAsync(string id)=> _menuRepositiry.DeleteAsync(id);
    }
}