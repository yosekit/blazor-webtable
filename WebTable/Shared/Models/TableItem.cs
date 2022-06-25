using System.ComponentModel.DataAnnotations;

namespace WebTable.Shared.Models
{
    public class TableItem
    {
        [Key]
        public int Id { get; set; }

        public int ColumnId { get; set; }
        public TableColumn Column { get; set; }

        public int RowId { get; set; }
        public TableRow Row { get; set; }

        public string Content { get; set; } = string.Empty;
    }
}
