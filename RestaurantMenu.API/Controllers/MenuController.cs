using Microsoft.AspNetCore.Mvc;
using RestaurantMenu.API.Models;
using RestaurantMenu.API.Services;

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
    }
}