using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        [HttpPost]
        public async Task<ActionResult<TableColumn>> PostColumn(TableColumn column)
        {
            _context.Columns.Add(column);

            await _context.SaveChangesAsync();

            return await Task.FromResult(column);
        }
    }
}
