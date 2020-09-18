using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebsiteLicenceApp.Areas.Licence.Models;

using WebsiteLicenceApp.Models;
using WebsiteLicenceApp.Areas.Orders.Models;

namespace WebsiteLicenceApp.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
           
        }
        public DbSet<UserLicence> UserLicence { get; set; }
        public DbSet<TypeLicences> TypeLicences { get; set; }
        public DbSet<WebsiteLicenceApp.Areas.Orders.Models.Order> Order { get; set; }

       

    }
}
