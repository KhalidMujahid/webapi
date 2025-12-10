using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private static readonly List<string> items = new List<string>
        {
            "Item1",
            "Item2",
            "Item3"
        };

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetItems()
        {
            return Ok(items);
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetItem(int id)
        {
            var item = items.ElementAtOrDefault(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public ActionResult AddItem([FromBody] string newItem)
        {
            if (string.IsNullOrEmpty(newItem))
            {
                return BadRequest("Item cannot be empty.");
            }
            
            items.Add(newItem);
            return CreatedAtAction(nameof(GetItem), new { id = items.Count - 1 }, newItem);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id, [FromBody] string updatedItem)
        {
            if (string.IsNullOrEmpty(updatedItem))
            {
                return BadRequest("Item cannot be empty.");
            }

            var itemIndex = id;
            if (itemIndex < 0 || itemIndex >= items.Count)
            {
                return NotFound();
            }

            items[itemIndex] = updatedItem;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(int id)
        {
            if (id < 0 || id >= items.Count)
            {
                return NotFound();
            }

            items.RemoveAt(id);
            return NoContent();
        }
    }
}
