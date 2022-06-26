using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebTable.Server.Controllers
{
    [Route("api/table/columns")]
    [ApiController]
    public class TableColumnController : ControllerBase
    {
        private readonly DataContext _context;
        public TableColumnController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TableColumn>>> GetColumns()
        {
            return await _context.Columns.ToListAsync();
        } 
    }
}
