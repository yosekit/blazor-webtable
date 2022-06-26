using WebTable.Shared.Models;

namespace WebTable.Client.Services
{
    public class TableItemService : TableService<TableItem>
    {
        public TableItemService(HttpClient http) : base(http)
        {
        }

        protected override void OnInitializedUri()
        {
            _uriGetAll = "api/table/items";
        }
    }
}
