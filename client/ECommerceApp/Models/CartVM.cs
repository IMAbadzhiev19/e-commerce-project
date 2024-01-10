namespace ECommerceApp.Models
{
    public class CartVM
    {
        public Guid Id { get; set; }

        public ICollection<ProductVM> Products { get; set; } = default!;
    }
}
