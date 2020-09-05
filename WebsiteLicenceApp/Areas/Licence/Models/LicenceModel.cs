using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteLicenceApp.Models
{
    public class LicenceModel
    {
        [Key]
        public int Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Licence { get; set; }
        public bool Paid { get; set; }
    }
}
