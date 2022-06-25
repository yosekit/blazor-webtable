using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebTable.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableRowsController : ControllerBase
    {
        private readonly DataContext _context;
        public TableRowsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TableRow>>> Get() =>
            Ok(await _context.Rows.ToListAsync());
    }
}
