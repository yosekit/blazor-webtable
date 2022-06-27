using WebTable.Shared.Models;

namespace WebTable.Client.Services
{
    public class TableColumnTypeService : TableService<TableColumnType>
    {
        public TableColumnTypeService(HttpClient http) : base(http)
        {
        }

        protected override void OnInitializedUri()
        {
            _requestUri = "api/table/columntypes";
        }
    }
}
