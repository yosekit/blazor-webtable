using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using WebTable.Shared.Models;

namespace WebTable.Client.Pages
{
    public partial class Table
    {
        public List<TableColumn>? Columns { get; set; }
        public List<TableRow>? Rows { get; set; }
        public List<TableItem>? Items { get; set; }

        [Inject]
        public HttpClient Http { get; set; } = default!;

        public TableItem GetTableItem(TableRow row, TableColumn column)
        {
            if (Items is null || !Items.Any())
                return new TableItem();

            return Items[0];
        }

        protected override async Task OnInitializedAsync()
        {
            Columns = await Http.GetFromJsonAsync<List<TableColumn>>("api/TableColumns");
            Rows    = await Http.GetFromJsonAsync<List<TableRow>>("api/TableRows");
            Items   = await Http.GetFromJsonAsync<List<TableItem>>("api/TableItems");
        }
    }
}
