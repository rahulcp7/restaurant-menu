using MongoDB.Driver;
using RestaurantMenu.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantMenu.API.Repositories
{
    public class MongoRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly IMongoCollection<T> _collection;

        public MongoRepository(IMongoDatabase database,string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<List<T>> GetAllAsync() =>
            await _collection.Find(_=>true).ToListAsync();

        public async Task<T?> GetByIdAsync(string id)=>
            await _collection.Find(x=>x.Id ==id).FirstOrDefaultAsync();

        public async Task CreateAsync(T entity)=>
            await _collection.InsertOneAsync(entity);

        public async Task UpdateAsync(string id, T entity) =>
            await _collection.ReplaceOneAsync(x=>x.Id == id,entity);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}