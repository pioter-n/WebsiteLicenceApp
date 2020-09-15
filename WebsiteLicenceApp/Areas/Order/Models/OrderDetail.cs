using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteLicenceApp.Models;

namespace WebsiteLicenceApp.Areas.Order.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public ApplicationUser Username { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public double? UnitPrice { get; set; }
    }
}
