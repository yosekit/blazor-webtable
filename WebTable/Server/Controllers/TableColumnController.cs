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
            using(IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Columns.Add(column);

                    await _context.SaveChangesAsync();

                    var rows = await _context.Rows.ToListAsync();
                    foreach (var row in rows)
                    {
                        _context.Items.Add(new TableItem
                        {
                            RowId = row.Id,
                            ColumnId = column.Id
                        });
                    }

                    await _context.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }

            return await Task.FromResult(column);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TableColumn>> DeleteColumn(int id)
        {
            var column = await _context.Columns.FindAsync(id);

            if (column is null)
            {
                return NotFound();
            }

            _context.Columns.Remove(column);

            await _context.SaveChangesAsync();

            return Ok(column);
        }
    }
}
