namespace ECommerceApp.Models
{
    public class Wishlist
    {
        public Guid Id { get; set; }

        public virtual ICollection<ProductVM> Products { get; set; } = default!;
    }
}
