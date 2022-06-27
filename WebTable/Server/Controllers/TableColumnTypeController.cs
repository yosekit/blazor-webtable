using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebTable.Server.Controllers
{
    [Route("api/table/columntypes")]
    [ApiController]
    public class TableColumnTypeController : ControllerBase
    {
        private readonly DataContext _context;
        public TableColumnTypeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TableColumnType>>> GetColumnTypes()
        {
            return await _context.ColumnTypes.ToListAsync();
        }
    }
}
