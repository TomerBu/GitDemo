using Sherlock.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sherlock.DAL
{
    public class SherlockContext:DbContext
    {
        public SherlockContext():base("SherlockDb")
        {
        }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Apartment> Appartments { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<District> Districts { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Address>().HasKey(a => a.ApartmentID);

            //modelBuilder.Entity<Apartment>().HasRequired(a => a.Address)
            //    .WithRequiredPrincipal(ad => ad.Apartment);
 
        }
    }
}