using System.Collections.Generic;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.Migrations
{
    public class CatagorieSeed
    {
        public List<Catagorie> List = new List<Catagorie> {
            new Catagorie { ID = 1, Name = "Whips" },
                new Catagorie { ID = 2, ParentID = 1, Name = "Bull Whips" },
                new Catagorie { ID = 3, ParentID = 1, Name = "Snake Whips" },
            new Catagorie { ID = 4, Name = "Wearables" },
                new Catagorie { ID = 5, ParentID = 4, Name = "Bracelets" },
                new Catagorie { ID = 6, ParentID = 4, Name = "Necklaces" },
            new Catagorie { ID = 7, Name = "Leash & Collar" },
                new Catagorie { ID = 8, ParentID = 7, Name = "Leashes" },
                new Catagorie { ID = 9, ParentID = 7, Name = "Collars" },
                new Catagorie { ID = 10, ParentID = 7, Name = "Bindings" },
        };

        public void Seed(ApplicationDbContext context) {
            List.ForEach(f => context.Catagories.Add(f));
            context.SaveChanges();
        }
    }
}