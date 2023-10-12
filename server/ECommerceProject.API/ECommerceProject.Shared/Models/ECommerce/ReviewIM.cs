using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.Shared.Models.ECommerce
{
    public class ReviewIM
    {
        public string? UserId { get; set; }

        public Guid ProductId {  get; set; }
        
        public int? Grade { get; set; }
    }
}
