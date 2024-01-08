namespace ECommerceApp.Models
{
    public class OrderVM
    {
        public Guid Id { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public Guid? CartId { get; set; }
    }
}
