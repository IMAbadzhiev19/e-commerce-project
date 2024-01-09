using ECommerceApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using System.Text;

namespace ECommerceApp.EndpointsMethods
{
    public class WishlistEndpoints
    {
        private readonly HttpClient _httpClient;

        public WishlistEndpoints(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Guid> CreateAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"api/wishlists/create");

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

        public async Task<Wishlist> GetWishList()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"api/wishlists/get-wishlist");

            Wishlist wishlist = new();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                wishlist = JsonConvert.DeserializeObject<Wishlist>(data);
            }

            return wishlist;
        }

        public async Task<HttpResponseMessage> AssignProduct(Guid wishlistId, Guid productId)
        {
            var contentQuery = JsonConvert.SerializeObject(new { 
                productId = productId
            });

            HttpContent content = new StringContent(contentQuery, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + $"api/wishlists/assign-product{wishlistId}", content);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteProduct(Guid wishlistId, Guid productId)
        {
            var contentQuery = JsonConvert.SerializeObject(new
            {
                productId = productId
            });

            HttpContent content = new StringContent(contentQuery, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + $"api/wishlists/remove-product{wishlistId}", content);
            return response;
        }
    }
}
