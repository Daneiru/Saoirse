using System.Collections.Generic;
using OpenOrderFramework.Models;
using System.Data.Entity.Migrations;

namespace OpenOrderFramework.Migrations
{
    public class SeedCatagorie
    {
        public List<Catagorie> List = new List<Catagorie> {
            new Catagorie { CatagorieID = 1, Name = "Whips" },
                new Catagorie { CatagorieID = 2, ParentID = 1, Name = "Bull Whips" },
                new Catagorie { CatagorieID = 3, ParentID = 1, Name = "Snake Whips" },
            new Catagorie { CatagorieID = 4, Name = "Wearables" },
                new Catagorie { CatagorieID = 5, ParentID = 4, Name = "Bracelets" },
                new Catagorie { CatagorieID = 6, ParentID = 4, Name = "Necklaces" },
            new Catagorie { CatagorieID = 7, Name = "Leash & Collar" },
                new Catagorie { CatagorieID = 8, ParentID = 7, Name = "Leashes" },
                new Catagorie { CatagorieID = 9, ParentID = 7, Name = "Collars" },
                new Catagorie { CatagorieID = 10, ParentID = 7, Name = "Bindings" },
        };

        public void Seed(ApplicationDbContext context) {
            List.ForEach(f => context.Catagories.AddOrUpdate(f));
            context.SaveChanges();
        }
    }
}