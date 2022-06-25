using System.ComponentModel.DataAnnotations;

namespace WebTable.Shared.Models
{
    public class TableColumn
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int TypeId { get; set; }
        public TableColumnType.DataType Type { get; set; }
    }

    public class TableColumnType
    {
        public enum DataType
        { 
            Text,
            Number,
            Date,
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public DataType Name { get; set; }
    }
}
