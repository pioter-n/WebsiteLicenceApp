using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteLicenceApp.Areas.Licence.Models;

namespace WebsiteLicenceApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {
        }
        public ApplicationUser(string userName) : base(userName)
        {
        }
        public virtual ICollection<UserLicence> UserLicences { get; set; }
    }
}
