using System.ComponentModel.DataAnnotations;

namespace WebTable.Shared.Models
{
    public class TableRow
    {
        [Key]
        public int Id { get; set; }
    }
}
