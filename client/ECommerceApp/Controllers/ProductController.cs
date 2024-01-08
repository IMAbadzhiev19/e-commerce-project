using ECommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace ECommerceApp.Controllers
{

    [Route("/Product/")]
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
            _httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjBjOGZkYWUwLTkxZWUtNGRiNS1hZmUwLTU3MjczYmM3MDc1ZCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlVzZXIiLCJleHAiOjE3MDQ2NTk4NjJ9.jn1u21aOq0hLD0A696Z5rJjzOekNyKXlK5HGWEIYfEs");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddWishList(string productId, string wishlistId)
        {
            return View();
        }

        public IActionResult WishList(string wishListId) {
            return View();
        }

        public IActionResult RemoveFromWishList(string productId, string wishlistId)
        {
            return View();
        }

        //-----------------------------------------------------------------------------------

        [HttpPost("UpdateOrder")]
        public async Task<IActionResult> UpdateOrderGet([FromForm] OrderVM order)
        {
            if (ModelState.IsValid)
            {
                var contentQuery = JsonConvert.SerializeObject(order);
                HttpContent content = new StringContent(contentQuery, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + $"api/orders/update{order.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Error", "Home");
            }

            return View();
        }

        [HttpGet("{Id}/UpdateOrder")]
        public async Task<IActionResult> UpdateOrder([FromRoute]int Id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"api/orders/get-order{Id}");

            OrderVM order = new();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                order = JsonConvert.DeserializeObject<OrderVM>(data);
            }

            return View(order);
        }

        [HttpGet("GetOrders")]
        public async Task<IActionResult> Orders()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"api/orders/get-orders");

            List<OrderVM> orders = new();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                orders = JsonConvert.DeserializeObject<List<OrderVM>>(data);
            }

            return View(orders);
        }

        [HttpGet("{Id}/GetSingleOrder")]
        public async Task<IActionResult> SingleOrder([FromRoute]int Id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"api/orders/get-order{Id}");

            OrderVM order = new();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                order = JsonConvert.DeserializeObject<OrderVM>(data);
            }

            return View(order);
        }

        [HttpGet("{Id}/DeleteOrder")]
        public async Task<IActionResult> DeleteOrder([FromRoute]int Id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"api/orders/remove{Id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        //-----------------------------------------------------------------------------------

        [HttpGet("AddProuct")]
        public IActionResult AddProduct()
        {
            ProductMV productMV = new ProductMV();
            return View(productMV);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromForm] ProductMV product)
        {
            if (ModelState.IsValid)
            {
                var contentQuery = JsonConvert.SerializeObject(product);
                HttpContent content = new StringContent(contentQuery, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "api/products/create", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Error", "Home");
            }

            return View();
        }

        [HttpGet("{Id}/Edit")]
        public async Task<IActionResult> EditProduct([FromRoute]int Id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"api/products/get-product{Id}");

            ProductMV product = new();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<ProductMV>(data);
            }

            return View(product);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> EditProductInfo([FromForm] ProductMV product)
        {
            if (ModelState.IsValid)
            {
                var contentQuery = JsonConvert.SerializeObject(product);
                HttpContent content = new StringContent(contentQuery, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + $"api/products/update{product.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Error", "Home");
            }

            return View();
        }

        [HttpGet("{Id}/Delete")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int Id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"api/products/remove{Id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index","Home");
        }

        [HttpGet("AllProducts")]
        public IActionResult Products()
        {
            List<ProductMV> products = new();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "api/products/get-products").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<ProductMV>>(data);
            }

            return View(products);
        }

        [HttpGet("SingleProduct")]
        public async Task<IActionResult> SingleProduct(string Id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"api/products/get-product{Id}");

            ProductMV product = new();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<ProductMV>(data);
            }

            return View(product);
        }

        //-----------------------------------------------------------------------------------

        [HttpGet("CreateComment")]
        public async Task<IActionResult> CreateComment([FromForm] CommentVM comment)
        {
            if (ModelState.IsValid)
            {
                var contentQuery = JsonConvert.SerializeObject(comment);
                HttpContent content = new StringContent(contentQuery, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "api/comments/create", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Error", "Home");
            }

            return View();
        }

        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateComment()
        {
            CommentVM comment = new();

            return View(comment);
        }

        [HttpGet("{Id}/RemoveComment")]
        public async Task<IActionResult> RemoveComment([FromRoute]int Id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"api/comments/remove{Id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("{productId}/GetComments")]
        public async Task<IActionResult> GetComments([FromRoute]int productId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"api/products/get-product{productId}");

            CommentVM comments = new();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                comments = JsonConvert.DeserializeObject<CommentVM>(data);
            }

            return View(comments);
        }

        //-----------------------------------------------------------------------------------
        public IActionResult RemoveFromCart(string cartId, string productId)
        {
            return View();
        }

        public IActionResult AddToCart(string cartId, string productId)
        {
            return View();
        }

        public IActionResult FinishOrder(string orderId)
        {
            return View();
        }
    }
}