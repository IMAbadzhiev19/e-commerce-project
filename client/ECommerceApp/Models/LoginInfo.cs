namespace ECommerceApp.Models
{
    public class LoginInfo
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public string Expiration { get; set; }
    }
}
