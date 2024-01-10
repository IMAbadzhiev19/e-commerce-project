using ECommerceApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace ECommerceApp.EndpointsMethods
{
    public class CartEndpoints
    {
        private readonly HttpClient _httpClient;
        public CartEndpoints(HttpClient _httpClient)
        {
            this._httpClient = _httpClient;
        }

        public async Task<Guid> CreateAsync(Guid userId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"api/carts/create{userId}");

            Guid result;

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

        public async Task<HttpResponseMessage> AssignProduct(Guid cratdId, Guid productId)
        {
            var contentQuery = JsonConvert.SerializeObject(new
            {
                productId = productId,
                cartId = cratdId
            });

            HttpContent content = new StringContent(contentQuery, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + $"api/carts/assign-product", content);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteProduct(Guid cratdId, Guid productId)
        {
            var contentQuery = JsonConvert.SerializeObject(new
            {
                productId = productId,
                cartId = cratdId
            });

            HttpContent content = new StringContent(contentQuery, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + $"api/carts/remove-product", content);
            return response;
        }

        public async Task<CartVM> GetCart()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"api/carts/get-cart");

            CartVM cart = new();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                cart = JsonConvert.DeserializeObject<CartVM>(data);
            }

            return cart; 
        }
    }
}
