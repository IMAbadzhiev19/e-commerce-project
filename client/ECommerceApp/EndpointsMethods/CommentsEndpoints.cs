using ECommerceApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace ECommerceApp.EndpointsMethods
{
    public class CommentsEndpoints
    {
        private readonly HttpClient _httpClient;
        public CommentsEndpoints(HttpClient _httpClient)
        {
            this._httpClient = _httpClient;
        }

        public async Task<List<CommentVM>> GetComments(int productId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"api/comments/get-comments{productId}");

            List<CommentVM> comments = new();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                comments = JsonConvert.DeserializeObject<List<CommentVM>>(data);
            }

            return comments;
        }

        public async Task<HttpResponseMessage> AddComment(CommentVM comment)
        {
            var contentQuery = JsonConvert.SerializeObject(comment);
            HttpContent content = new StringContent(contentQuery, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "api/comments/create", content);
            return response;
        }

    }
}
