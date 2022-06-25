using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebTable.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableColumnsController : ControllerBase
    {
        private readonly DataContext _context;
        public TableColumnsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TableColumn>>> Get() => 
            Ok(await _context.Columns.ToListAsync());
    }
}
