namespace ECommerceApp.Models
{
    public class ProductVM
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public decimal? Price { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public int? Quantity { get; set; }

        public ICollection<CommentVM>? Comments { get; set;}
    }
}
