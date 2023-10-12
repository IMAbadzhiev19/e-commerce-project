using ECommerceProject.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.Shared.Models.ECommerce;

public class OrderIM
{
    public Status Status { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime DeliveryDate { get; set; }

    public Guid CartId { get; set; }
}
