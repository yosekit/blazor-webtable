﻿using WebTable.Shared.Models;

namespace WebTable.Client.Services
{
    public class TableRowService : TableService<TableRow>
    {
        public TableRowService(HttpClient http) : base(http)
        {
        }

        protected override void OnInitializedUri()
        {
            _requestUri = "api/table/rows";
        }
    }
}
