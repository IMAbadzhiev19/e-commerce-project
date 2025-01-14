﻿using ECommerceApp.Models;
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
            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + $"api/wishlists/create",null);

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
            else
            {
                Guid result = await CreateAsync();
                return await GetWishList();
            }

            return wishlist;
        }

        public async Task<HttpResponseMessage> AssignProduct(Guid productId)
        {
            var wishlistId = (await GetWishList()).Id;

            var httpReponse = await _httpClient.PutAsync(_httpClient.BaseAddress + $"api/wishlists/assign-product/{wishlistId}?productId={productId}", null);

            return httpReponse;
        }

        public async Task<HttpResponseMessage> DeleteProduct(Guid wishlistId, Guid productId)
        {
            var httpReponse = await _httpClient.PutAsync(_httpClient.BaseAddress + $"api/wishlists/remove-product/{wishlistId}?productId={productId}", null);

            return httpReponse;
        }
    }
}
