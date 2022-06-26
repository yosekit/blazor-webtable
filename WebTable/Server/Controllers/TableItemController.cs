using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebTable.Server.Controllers
{
    [Route("api/[controller]")]
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
    }
}
