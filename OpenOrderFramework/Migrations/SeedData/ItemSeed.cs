using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.Migrations
{
    public class ItemSeed
    {
        public List<Item> List = new List<Item> {
            new Item { ID = 1, CatagorieId = 1, Name = "", Price = 0.00m }
        };

        public void Seed(ApplicationDbContext context) {
            List.ForEach(f => context.Items.Add(f));
            context.SaveChanges();
        }
    }
}