using LicenceApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicenceApplication
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=LicenceClientDb;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
    }
}
