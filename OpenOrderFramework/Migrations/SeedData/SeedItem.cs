using System.Collections.Generic;
using OpenOrderFramework.Models;
using System.Data.Entity.Migrations;

namespace OpenOrderFramework.Migrations
{
    public class SeedItem
    {
        public List<RegularItem> List = new List<RegularItem> {
            new RegularItem { ItemID = 1, CatagorieID = 3, Name = "Ouroburos", Price = 229.90m }
        };

        public void Seed(ApplicationDbContext context) {
            List.ForEach(f => context.Items.AddOrUpdate(f));
            context.SaveChanges();
        }
    }
}