using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantMenu.API.Models;

namespace RestaurantMenu.API.Services
{
    public interface IMenuService
    {
        Task<List<MenuItem>> GetAllAsync();
        Task<MenuItem?> GetByIdAsync(string id);
        Task CreateAsync(MenuItem item);
        Task UpdateAsync(string id, MenuItem item);
        Task DeleteAsync(string id);
    }
}