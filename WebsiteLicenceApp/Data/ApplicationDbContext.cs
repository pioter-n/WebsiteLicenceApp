using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebsiteLicenceApp.Areas.Licence.Models;
using WebsiteLicenceApp.Areas.Order.Models;
using WebsiteLicenceApp.Models;

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

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
