using ECommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using ECommerceApp.EndpointsMethods;

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
                OrderEndpoints orderEndpoints = new(this._httpClient);
                HttpResponseMessage response = await orderEndpoints. UpdateProduct(order);

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
            OrderEndpoints orderEndpoints = new(this._httpClient);
            OrderVM order = await orderEndpoints.GetOrder(Id);

            return View(order);
        }

        [HttpGet("GetOrders")]
        public async Task<IActionResult> Orders()
        {
            OrderEndpoints orderEndpoints = new(this._httpClient);
            List<OrderVM> orders = await orderEndpoints.GetOrders();

            return View(orders);
        }

        [HttpGet("{Id}/GetSingleOrder")]
        public async Task<IActionResult> SingleOrder([FromRoute]int Id)
        {
            OrderEndpoints orderEndpoints = new(this._httpClient);
            OrderVM order = await orderEndpoints.GetOrder(Id);

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
            ProductVM productMV = new ProductVM();
            return View(productMV);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromForm] ProductVM product)
        {
            ProductEndpoints productEndpoints = new(this._httpClient);
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await productEndpoints.AddProduct(product);

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
            ProductEndpoints productEndpoints = new(this._httpClient);
            ProductVM product = await productEndpoints.SingleProduct(Id);

            return View(product);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> EditProductInfo([FromForm] ProductVM product)
        {
            ProductEndpoints productEndpoints = new(this._httpClient);
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await productEndpoints.Update(product);

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
        public async Task<IActionResult> Products()
        {
            ProductEndpoints productEndpoints = new(this._httpClient);
            List<ProductVM> products = await productEndpoints.GetProducts();

            return View(products);
        }

        [HttpGet("SingleProduct")]
        public async Task<IActionResult> SingleProduct(int Id)
        {
            ProductEndpoints productEndpoints = new(this._httpClient);
            ProductVM product = await productEndpoints.SingleProduct(Id);

            return View(product);
        }

        //-----------------------------------------------------------------------------------

        [HttpGet("CreateComment")]
        public async Task<IActionResult> CreateComment([FromForm] CommentVM comment)
        {
            if (ModelState.IsValid)
            {
                CommentsEndpoints commentsEndpoints = new(_httpClient);
                HttpResponseMessage response = await commentsEndpoints.AddComment(comment);

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