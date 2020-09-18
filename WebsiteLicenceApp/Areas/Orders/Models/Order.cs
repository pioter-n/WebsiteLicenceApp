using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebsiteLicenceApp.Areas.Licence.Models;

namespace WebsiteLicenceApp.Areas.Orders.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string IdUser { get; set; }
        public TypeLicences TypeLicence { get; set; }
        public bool Actual { get; set; }
    }
}
