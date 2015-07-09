using System.Collections.Generic;
using OpenOrderFramework.Models;
using System.Data.Entity.Migrations;

namespace OpenOrderFramework.Migrations
{
    public class SeedDesignerCatagorie
    {
        public List<DesignerCatagorie> List = new List<DesignerCatagorie> {
            new DesignerCatagorie { DesignerCatagorieID = 1, Name = "Whips" },
            new DesignerCatagorie { DesignerCatagorieID = 2, Name = "Wearables" },
            new DesignerCatagorie { DesignerCatagorieID = 3, Name = "Leash & Collar" },
        };

        public void Seed(ApplicationDbContext context) {
            List.ForEach(f => context.DesignerCatagories.AddOrUpdate(f));
            context.SaveChanges();
        }
    }
}