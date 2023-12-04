using ECommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ECommerceApp.Controllers
{
    public class ProductController : Controller
    {
        private Uri _uri = new Uri("https://localhost:7148/");
        private readonly HttpClient _httpClient;

        public ProductController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = _uri;
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjZjODkyMDY5LTE0YzAtNGM1MS04ODAzLTU5ZGQyYjlmNGZhMiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlVzZXIiLCJleHAiOjE3MDE3MjIzNzB9.EXkUgug4PvLd1rleoWDga3bFbu8u0HeSKsp9lHBujbA");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            List<ProductMV> products = new();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "api/products/get-products").Result;

            if(response.IsSuccessStatusCode) 
            {
                string data = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<ProductMV>>(data);
            }
            
            return View(products);
        }
    }
}
