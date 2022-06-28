using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebTable.Shared.Models;

namespace WebTable.Shared.Validations
{
    public class ContentDataTypeAttribute: ValidationAttribute
    {
        private readonly Dictionary<TableColumnTypeId, Type> _mapDataTypes = new()
        {
            { TableColumnTypeId.Text, typeof(string) },
            { TableColumnTypeId.Number, typeof(int) },
            { TableColumnTypeId.Date, typeof(DateTime) },
        };

        public ContentDataTypeAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            TableItem item = value as TableItem;

            return TypeDescriptor.GetConverter(_mapDataTypes[item.Column.TypeId]) is not null;
        }
    }
}
