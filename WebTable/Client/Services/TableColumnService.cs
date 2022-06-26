using WebTable.Shared.Models;

namespace WebTable.Client.Services
{
    public class TableColumnService : TableService<TableColumn>
    {
        public TableColumnService(HttpClient http) : base(http)
        {
        }

        protected override void OnInitializedUri()
        {
            _requestUri = "api/table/columns";
        }
    }
}
