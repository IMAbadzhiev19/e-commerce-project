namespace ECommerceApp.Models
{
    public class ProductMV
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public decimal? Price { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public int? Quantity { get; set; }

    }
}
