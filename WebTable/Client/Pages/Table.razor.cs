using Microsoft.AspNetCore.Components;
using WebTable.Shared.Models;

namespace WebTable.Client.Pages
{
    public partial class Table
    {
        public List<TableColumn>? Columns { get; set; }
        public List<TableRow>? Rows { get; set; }
        public List<TableItem>? Items { get; set; }

        public TableItem GetTableItem(TableRow row, TableColumn column)
        {
            if (Items is null || !Items.Any())
                return new TableItem();

            return Items[0];
        }

        protected override async Task OnInitializedAsync()
        {
            Columns = await tableColumnsService.GetAllAsync();
            Rows    = await tableRowsService.GetAllAsync();
            Items   = await tableItemsService.GetAllAsync();
        }

    }
}
