using System.Collections.Generic;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.Migrations
{
    public class DesignerCatagorieSeed
    {
        public List<DesignerCatagorie> List = new List<DesignerCatagorie> {
            new DesignerCatagorie { ID = 1, Name = "Whips" },
            new DesignerCatagorie { ID = 4, Name = "Wearables" },
            new DesignerCatagorie { ID = 7, Name = "Leash & Collar" },
        };

        public void Seed(ApplicationDbContext context) {
            List.ForEach(f => context.DesignerCatagories.Add(f));
            context.SaveChanges();
        }
    }
}