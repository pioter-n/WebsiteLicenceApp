namespace LicenceApplication
{
    using LicenceApplication.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AppContext : DbContext
    {
       
        public AppContext()
            : base("name=AppContext")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Licence> Licences { get; set; }


    }

    
}