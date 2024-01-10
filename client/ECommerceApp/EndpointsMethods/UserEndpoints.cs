using ECommerceApp.Models;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace ECommerceApp.EndpointsMethods
{
    //api/user/current-user
    //api/user/change-password
    //api/user/update-user-info
    public class UserEndpoints
    {
        private readonly HttpClient _httpClient;
        public UserEndpoints(HttpClient _httpClient)
        {
            this._httpClient = _httpClient;
        }

        public async Task<UserVM> GetUser()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"current-user");

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<UserVM>(data);

                return result;
            }

            return null;
        }

        public async Task<bool> ChangePassword(string oldPassword, string newPassword)
        {
            var contentQuery = JsonConvert.SerializeObject(new
            {
                oldPassword = oldPassword,
                newPassword = newPassword
            });

            HttpContent content = new StringContent(contentQuery, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + $"api/user/change-password", content);

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<Response>(data);

                return true;
            }

            return false;
        }


        public async Task<bool> UserInfoUpdate(UserVM user)
        {
            var contentQuery = JsonConvert.SerializeObject(user);

            HttpContent content = new StringContent(contentQuery, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + $"api/user/change-password", content);

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<Response>(data);

                return true;
            }

            return false;
        }
    }
}
