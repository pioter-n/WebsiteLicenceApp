using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebsiteLicenceApp.Models;

namespace WebsiteLicenceApp.Areas.Order.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public ApplicationUser Username { get; set; }

        public System.DateTime OrderDate { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [ScaffoldColumn(false)]
        public decimal Total { get; set; }

        [ScaffoldColumn(false)]
        public string PaymentTransactionId { get; set; }

        [ScaffoldColumn(false)]
        public bool HasBeenShipped { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
