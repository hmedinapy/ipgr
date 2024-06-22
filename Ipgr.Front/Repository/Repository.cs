
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;

namespace Ipgr.Front.Repository
{
    public class Repository : IRepository
    {
        public readonly HttpClient _httpClient;
        public JsonSerializerOptions _jsonSerializerOptions => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public Repository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseWrapper<T>> GetAsync<T>(string url)
        {
            var responsehttp = await _httpClient.GetAsync(url);
            if (responsehttp.IsSuccessStatusCode)
            {
                var response = await UnserializeAnswer<T>(responsehttp);
                return new HttpResponseWrapper<T>(response, false, responsehttp);
            }
            return new HttpResponseWrapper<T>(default, true, responsehttp);
        }

        public async Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T model)
        {
            var messageJson = JsonSerializer.Serialize(model);
            var messageContent = new StringContent(messageJson, Encoding.UTF8, "application/json");

            var responsehttp = await _httpClient.PostAsync(url, messageContent);
            return new HttpResponseWrapper<object>(null, !responsehttp.IsSuccessStatusCode, responsehttp);
        }

        public async Task<HttpResponseWrapper<TActionResponse>> PostAsync<T, TActionResponse>(string url, T model)
        {
            var messageJson = JsonSerializer.Serialize(model);
            var messageContent = new StringContent(messageJson, Encoding.UTF8, "application/json");

            var responsehttp = await _httpClient.PostAsync(url, messageContent);
            if (responsehttp.IsSuccessStatusCode)
            {
                var response = await UnserializeAnswer<TActionResponse>(responsehttp);
                return new HttpResponseWrapper<TActionResponse>(response, false, responsehttp);
            }
            return new HttpResponseWrapper<TActionResponse>(default, true, responsehttp);
        }

        private async Task<T> UnserializeAnswer<T>(HttpResponseMessage responsehttp)
        {
            var response = await responsehttp.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(response, _jsonSerializerOptions)!;
        }
    }
}
