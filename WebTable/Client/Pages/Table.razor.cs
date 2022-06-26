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

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                await LoadTableAsync();

                StateHasChanged();
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task LoadTableAsync()
        {
            Columns = await tableColumnService.GetAllAsync();
            Rows = await tableRowService.GetAllAsync();
            Items = await tableItemService.GetAllAsync();

            StateHasChanged();
        }

        private async Task AddColumn()
        {
            var column = new TableColumn();

            await tableColumnService.SaveAsync(column);

            await LoadTableAsync();
        }

        private async Task AddRow()
        {
            var row = new TableRow();

            await tableRowService.SaveAsync(row);

            await LoadTableAsync();
        }
    }
}
