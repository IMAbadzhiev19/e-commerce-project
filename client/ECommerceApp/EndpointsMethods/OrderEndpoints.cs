using ECommerceApp.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace ECommerceApp.EndpointsMethods
{
    public class OrderEndpoints
    {
        private readonly HttpClient _httpClient;
        public OrderEndpoints(HttpClient _httpClient) { 
            this._httpClient = _httpClient;
        }

        public async Task<HttpResponseMessage> UpdateProduct(OrderVM order)
        {
            var contentQuery = JsonConvert.SerializeObject(order);
            HttpContent content = new StringContent(contentQuery, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + $"api/orders/update{order.Id}", content);
            return response;
        }

        public async Task<OrderVM> GetOrder(int Id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"api/orders/get-order{Id}");

            OrderVM order = new();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                order = JsonConvert.DeserializeObject<OrderVM>(data);
            }

            return order;
        }

        public async Task<List<OrderVM>> GetOrders()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"api/orders/get-orders");

            List<OrderVM> orders = new();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                orders = JsonConvert.DeserializeObject<List<OrderVM>>(data);
            }

            return orders;
        }
    }
}
