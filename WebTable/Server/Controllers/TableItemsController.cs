using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebTable.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableItemsController : ControllerBase
    {
        private readonly DataContext _context;
        public TableItemsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TableItem>>> Get() =>
            Ok(await _context.Items.ToListAsync());
    }
}
