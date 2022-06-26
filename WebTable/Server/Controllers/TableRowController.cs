using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebTable.Server.Controllers
{
    [Route("api/table/rows")]
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

        [HttpPost]
        public async Task<ActionResult<TableRow>> PostRow(TableRow row)
        {
            _context.Rows.Add(row);
            await _context.SaveChangesAsync();

            return await Task.FromResult(row);
        }

    }
}
