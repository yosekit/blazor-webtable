using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebTable.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableRowController : ControllerBase
    {
        private readonly DataContext _context;
        public TableRowController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TableRow>>> GetRows()
        {
            return await _context.Rows.ToListAsync();
        }
    }
}
