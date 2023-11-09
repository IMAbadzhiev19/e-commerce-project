using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.ModelView;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private Uri _uri = new Uri("https://localhost:7007/");
        private readonly HttpClient _httpClient;

        public ProductController() 
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = _uri;
        }

        [HttpGet]
        public IActionResult getProduct()
        {
            List<ProductView> productViews = new();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "api/products/get-products").Result;

            if(response.IsSuccessStatusCode) 
            {
                string data = response.Content.ReadAsStringAsync().Result;
                productViews = JsonConvert.DeserializeObject<List<ProductView>>(data);
            }

            return View(productViews);
        }
    }
}
