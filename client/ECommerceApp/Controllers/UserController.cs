using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing.Imaging;
using System.Net.Http.Headers;
using ECommerceApp.Models;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.JSInterop;
using ECommerceApp.EndpointsMethods;

namespace WebApp.Controllers
{
    [Route("/User/")]
    public class UserController : Controller
    {
        private Uri _uri = new Uri("https://localhost:7148/");
        private readonly HttpClient _httpClient;
        private string _temporaryAccessToken;

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        public UserController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = _uri;
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _temporaryAccessToken = string.Empty;
            _httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjU0YjI0MjUzLTc2ZDEtNGJhMi1hNGUzLTBkOWZiYzQzNWJlNiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlVzZXIiLCJleHAiOjE3MDYwMDAxMjV9.1HIOGsRknwRH1QTj6JIg8YVXX6unN2O44LIl1vZgPzU");
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
        public async Task<IActionResult> Register([FromForm] UserVM user)
        {
            if (ModelState.IsValid)
            {
                var contentQuery = JsonConvert.SerializeObject(user);
                HttpContent content = new StringContent(contentQuery, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "api/auth/register", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Error","Home");
            }

            return View();
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login()
        {
            LoginMV login = new LoginMV();

            return View(login);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] LoginMV login)
        {
            if (ModelState.IsValid)
            {
                var contentQuery = JsonConvert.SerializeObject(login);
                HttpContent content = new StringContent(contentQuery, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "api/auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    var loginInfo = JsonConvert.DeserializeObject<LoginInfo>(data);
                    _httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"bearer {loginInfo?.AccessToken}");
                    return RedirectToAction("MainPage","User");
                }
            }

            return RedirectToAction("Error", "Home");
            }

        [HttpGet("MainPage")]
        public async Task<IActionResult> MainPage()
        {
            ProductEndpoints productEndpoints = new(_httpClient);
            ICollection<ProductVM> products = await productEndpoints.GetProducts();
            products = products.Take(10).ToList();

            return View(products);
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "api/auth/logout");

            return View();
        }

        [HttpGet("current-user")]
        public async Task<IActionResult> UserInfo()
        {
            UserEndpoints userEndpoints = new(_httpClient);
            var result = userEndpoints.GetUser();

            if (result != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Error", "Home");
        }

        [HttpPost("userUpdate")]
        public async Task<IActionResult> UserInfoUpdate()
        {
            UserEndpoints userEndpoints = new(_httpClient);
            var result = userEndpoints.GetUser();

            if (result != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Error", "Home");
        }

        [HttpGet("userUpdate")]
        public async Task<IActionResult> UserInfoUpdate([FromBody] UserVM user)
        {
            UserEndpoints userEndpoints = new(_httpClient);
            var result = userEndpoints.UserInfoUpdate(user);

            if (result != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Error", "Home");
        }

        [HttpGet("changePassword")]
        public async Task<IActionResult> ChangePassword()
        {
            ChangePassword changePassword = new ChangePassword();
            return View(changePassword);
        }

        [HttpGet("changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword changePassword)
        {
            UserEndpoints userEndpoints = new(_httpClient);
            var result = userEndpoints.ChangePassword(changePassword.OldPassword, changePassword.NewPassword);

            if (result != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Error", "Home");
        }
    }
}
