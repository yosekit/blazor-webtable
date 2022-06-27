using Microsoft.AspNetCore.Components;
using WebTable.Shared.Models;

namespace WebTable.Client.Pages
{
    public partial class Table
    {
        public List<TableColumn>? Columns { get; set; }
        public List<TableColumnType>? ColumnTypes { get; set; }
        public List<TableRow>? Rows { get; set; }
        public List<TableItem>? Items { get; set; }

        public TableColumn EditedColumn { get; set; } = new TableColumn();

        private void MapEditedColumn(TableColumn column)
        {
            EditedColumn = column;
        }

        public TableItem GetTableItem(TableRow row, TableColumn column)
        {
            return Items.FirstOrDefault(i => i.RowId == row.Id && i.ColumnId == column.Id);
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
            ColumnTypes = await tableColumnTypeService.GetAllAsync();
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

        private async Task DeleteColumn(int id)
        {
            await tableColumnService.DeleteAsync(id);

            await LoadTableAsync();
        }

        private async Task EditColumn()
        {
            await tableColumnService.UpdateAsync(EditedColumn);

            await LoadTableAsync();
        }

        private async Task AddRow()
        {
            var row = new TableRow();

            await tableRowService.SaveAsync(row);

            await LoadTableAsync();
        }

        private async Task DeleteRow(int id)
        {
            await tableRowService.DeleteAsync(id);

            await LoadTableAsync();
        }
    }
}
