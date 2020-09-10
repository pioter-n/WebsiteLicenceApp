using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteLicenceApp.Areas.Licence.Models
{
    public class TypeLicences
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Licence Name")]
        public string Name { get; set; }
        [DisplayName("Month")]
        public int Month { get; set; }
    }
}
