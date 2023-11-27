using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing.Imaging;
using System.Net.Http.Headers;
using ECommerceApp.Models;

namespace WebApp.Controllers
{
    [Route("/User/")]
    public class UserController : Controller
    {
        private Uri _uri = new Uri("https://localhost:7148/");
        private readonly HttpClient _httpClient;

        [HttpGet("he")]
        public IActionResult Index()
        {
            return View();
        }

        public UserController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = _uri;
            _httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjA0NWMwMzJjLWNiZWItNDk2NS1iOGNlLTQ1MWRmNWJjM2E2NiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlVzZXIiLCJleHAiOjE2OTk5ODUyMDN9.I9JFGzz3-Cqqpx9KmE4c0fdDxTVH-ohCy_2M0rlN7po");
        }


        [HttpGet("Register")]
        public IActionResult Register()
        {
            var user = new UserVM();
            return View(user);
        }

        //List<ProductView> productViews = new();
        //HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "api/products/get-products").Result;

        //if(response.IsSuccessStatusCode) 
        //{
        //    string data = response.Content.ReadAsStringAsync().Result;
        //    productViews = JsonConvert.DeserializeObject<List<ProductView>>(data);
        //}

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm]UserVM user)
        {
            var hello = 5;
            if (ModelState.IsValid)
            {
                string contentQuery = JsonConvert.SerializeObject(user);
                HttpContent content = new StringContent(contentQuery);

                var request = new HttpRequestMessage();
                request.Content = content;
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(_httpClient.BaseAddress + "api/auth/register");

                HttpResponseMessage response = await _httpClient.SendAsync(request);

                var result = await response.Content.ReadAsStringAsync();

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
