using System.Net.Http.Json;
using WebTable.Shared.Models;

namespace WebTable.Client.Services
{
    public abstract class TableService<T> : ITableService<T>
    {
        protected string _uriGetAll = string.Empty;

        protected readonly HttpClient _http;

        public TableService(HttpClient http)
        {
            _http = http;

            OnInitializedUri();
        }

        protected abstract void OnInitializedUri();

        public async Task<List<T>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<T>>(_uriGetAll);
        }
    }
}
