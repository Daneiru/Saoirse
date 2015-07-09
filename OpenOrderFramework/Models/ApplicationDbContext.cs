﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OpenOrderFramework.Models {
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager) {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false) { }

        static ApplicationDbContext() {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create() {
            return new ApplicationDbContext();
        }

        // Pre-existing.
        public DbSet<Item> Items { get; set; } // TPH: RegularItem, DesignerItem
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Catagorie> Catagories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        // Added.
        public DbSet<Image> Images { get; set; }
        public DbSet<ImageGroup> ImageGroups { get; set; }

        public DbSet<DesignerCatagorie> DesignerCatagories { get; set; }
        public DbSet<DesignerItem> DesignerItems { get; set; }
        public DbSet<DesignerItemOptionSet> DesignerItemOptionSets { get; set; }
        public DbSet<DesignerOption> DesignerOptions { get; set; }
        public DbSet<DesignerItemSelection> DesignerItemSelections { get; set; }
    }
}