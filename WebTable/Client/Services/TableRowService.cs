using WebTable.Shared.Models;

namespace WebTable.Client.Services
{
    public class TableRowService : TableService<TableRow>
    {
        public TableRowService(HttpClient http) : base(http)
        {
        }

        protected override void OnInitializedUri()
        {
            _uriGetAll = "api/table/rows";
            _uriSave = "api/table/rows";
        }
    }
}
