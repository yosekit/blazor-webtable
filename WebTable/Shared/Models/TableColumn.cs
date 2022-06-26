using System.ComponentModel.DataAnnotations;

namespace WebTable.Shared.Models
{
    public class TableColumn
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "Name";

        public TableColumnTypeId TypeId { get; set; } = TableColumnTypeId.Text;
        public TableColumnType Type { get; set; }
    } 
}
