using System.ComponentModel.DataAnnotations;

namespace WebTable.Shared.Models
{
    public enum TableColumnTypeId : int
    {
        Text = 0,
        Number = 1,
        Date = 2,
    }

    public class TableColumnType
    {
        [Key]
        public TableColumnTypeId Id { get; set; }

        public string Name { get; set; }

        public List<TableColumn> Columns { get; set; }
    }
}
