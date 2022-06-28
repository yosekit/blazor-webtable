using System.ComponentModel.DataAnnotations;
using WebTable.Shared.Validations;

namespace WebTable.Shared.Models
{
    public class TableItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ColumnId { get; set; }
        public TableColumn? Column { get; set; }

        [Required]
        public int RowId { get; set; }
        public TableRow? Row { get; set; }

        [ContentDataType]
        public string Content { get; set; } = string.Empty;
    }
}
