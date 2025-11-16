using Microsoft.AspNetCore.Mvc;
using RestaurantMenu.Data.Entities;
using RestaurantMenu.Business.Services;

namespace RestaurantMenu.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly MenuService _menuService;

        public MenuController(MenuService menuService)
        {
            _menuService=menuService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _menuService.GetAllAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuItem item)
        {
            await _menuService.CreateAsync(item);
            return CreatedAtAction(nameof(GetAll), new {id = item.Id},item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, MenuItem item)
        {
            var existing = await _menuService.GetByIdAsync(id);
            if(existing == null)
                return NotFound($"Menu item with ID {id} not found.");
            item.Id = id;
            await _menuService.UpdateAsync(id, item);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _menuService.GetByIdAsync(id);
            if (existing==null)
                return NotFound($"Menu item with ID {id} not found.");
            await _menuService.DeleteAsync(id);
            return NoContent();
        }

    }
}