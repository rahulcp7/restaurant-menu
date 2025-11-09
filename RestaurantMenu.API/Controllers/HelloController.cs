using Microsoft.AspNetCore.Mvc;

namespace RestaurantMenu.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController:ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Hello from Restaurant Menu API!");
    }
}