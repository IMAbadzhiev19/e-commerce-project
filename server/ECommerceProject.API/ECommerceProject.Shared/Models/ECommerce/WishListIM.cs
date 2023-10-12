using ECommerceProject.Data.Models.ECommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.Shared.Models.ECommerce
{
    public class WishListIM
    {
        public string? UserId { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
