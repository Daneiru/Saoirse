using System.Collections.Generic;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.Migrations
{
    public class DesignerCatagorieSeed
    {
        public List<DesignerCatagorie> List = new List<DesignerCatagorie> {
            new DesignerCatagorie { DesignerCatagorieID = 1, Name = "Whips" },
            new DesignerCatagorie { DesignerCatagorieID = 2, Name = "Wearables" },
            new DesignerCatagorie { DesignerCatagorieID = 3, Name = "Leash & Collar" },
        };

        public void Seed(ApplicationDbContext context) {
            List.ForEach(f => context.DesignerCatagories.Add(f));
            context.SaveChanges();
        }
    }
}