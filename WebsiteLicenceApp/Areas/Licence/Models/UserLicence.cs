using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebsiteLicenceApp.Models;

namespace WebsiteLicenceApp.Areas.Licence.Models
{
    public class UserLicence
    {
        [Key]
        public int Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Licences { get; set; }
        public bool Paid { get; set; }
        public virtual TypeLicences TypeLicience { get; set; }
        public DateTime Date { get; set; }
    }
}
