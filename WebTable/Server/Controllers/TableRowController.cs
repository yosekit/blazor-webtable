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
            using(IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Rows.Add(row);

                    await _context.SaveChangesAsync();

                    var columns = await _context.Columns.ToListAsync();

                    foreach (var column in columns)
                    {
                        _context.Items.Add(new TableItem
                        {
                            ColumnId = column.Id,
                            RowId = row.Id
                        }); ;
                    }

                    await _context.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }

            return await Task.FromResult(row);
        }

    }
}
