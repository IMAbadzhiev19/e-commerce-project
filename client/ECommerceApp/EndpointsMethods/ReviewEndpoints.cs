using ECommerceApp.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace ECommerceApp.EndpointsMethods
{
    public class ReviewEndpoints
    {
        private readonly HttpClient _httpClient;
        public ReviewEndpoints(HttpClient _httpClient)
        {
            this._httpClient = _httpClient;
        }

        public async Task<Guid> CreateAsync(Guid productId, int grade)
        {
            var contentQuery = JsonConvert.SerializeObject(new
            {
                grade = grade,
                productId = productId
            });

            HttpContent content = new StringContent(contentQuery, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + $"api/reviews/create", content);

            var result = new Guid();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<Guid>(data);

                return result;
            }
            else
            {
                return Guid.Empty;
            }
        }

        public async Task<bool> RemoveAsync(Guid reviewId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"api/reviews/remove{reviewId}");

            return response.IsSuccessStatusCode;
        }
    }
}
