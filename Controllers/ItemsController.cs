using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllItems(ItemsService _itemService)
        {
            return Ok(_itemService.GetItems());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetItem(int id,ItemsService _itemService)
        {
            return Ok(_itemService.GetItem(id));
        }
    }
}