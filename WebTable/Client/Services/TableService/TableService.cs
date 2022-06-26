using Newtonsoft.Json;
using WebTable.Shared.Models;

namespace WebTable.Client.Services
{
    public abstract class TableService<T> : ITableService<T>
    {
        protected string _requestUri = string.Empty;

        protected readonly HttpClient _http;

        public TableService(HttpClient http)
        {
            _http = http;

            OnInitializedUri();
        }

        protected abstract void OnInitializedUri();

        public async Task<List<T>> GetAllAsync()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, _requestUri);

            var response = await _http.SendAsync(requestMessage);
            
            var resonseStatusCode = response.StatusCode;
            if(resonseStatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseBody = await response.Content.ReadAsStringAsync();

                return await Task.FromResult(JsonConvert.DeserializeObject<List<T>>(responseBody));
            }
            else
            {
                return null;
            }
        }

        public async Task<T> SaveAsync(T obj)
        {
            string serializedOjb = JsonConvert.SerializeObject(obj);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, _requestUri);

            requestMessage.Content = new StringContent(serializedOjb);
            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _http.SendAsync(requestMessage);

            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedObj = JsonConvert.DeserializeObject<T>(responseBody);

            return await Task.FromResult(returnedObj);
        }
    }
}
