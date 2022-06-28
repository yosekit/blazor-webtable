using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebTable.Server.Controllers
{
    [Route("api/table/items")]
    [ApiController]
    public class TableItemController : ControllerBase
    {
        private readonly DataContext _context;
        public TableItemController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TableItem>>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        [HttpPut]
        public async Task<ActionResult<TableItem>> PutItem(TableItem item)
        {
            bool foundItem = await _context.Items.AnyAsync(i => i.Id == item.Id);

            if (!foundItem)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            _context.Entry(item).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(item);
        }
    }
}
