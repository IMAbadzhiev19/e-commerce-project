using ECommerceApp.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace ECommerceApp.EndpointsMethods
{
    public class ProductEndpoints
    {
        private readonly HttpClient _httpClient;
        public ProductEndpoints(HttpClient _httpClient)
        {
            this._httpClient = _httpClient;
        }

        public async Task<HttpResponseMessage> AddProduct(ProductVM product)
        {
            var contentQuery = JsonConvert.SerializeObject(product);
            HttpContent content = new StringContent(contentQuery, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "api/products/create", content);
            return response;
        }

        public async Task<ProductVM> SingleProduct(int Id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"api/products/get-product{Id}");

            ProductVM product = new();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<ProductVM>(data);
            }

            CommentsEndpoints commentsEndpoints = new(_httpClient);
            product.Comments = await commentsEndpoints.GetComments(Id);

            return product;
        }

        public async Task<List<ProductVM>> GetProducts()
        {
            List<ProductVM> products = new();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "api/products/get-products").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<ProductVM>>(data);
            }

            CommentsEndpoints commentsEndpoints = new(_httpClient);
            foreach (ProductVM pr in products)
            {
                pr.Comments = await commentsEndpoints.GetComments(pr.Id);
            }

            return products;
        }

        public async Task<HttpResponseMessage> Update(ProductVM product)
        {
            var contentQuery = JsonConvert.SerializeObject(product);
            HttpContent content = new StringContent(contentQuery, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + $"api/products/update{product.Id}", content);
            return response;
        }
    }
}
