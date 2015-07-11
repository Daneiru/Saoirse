using System.Collections.Generic;
using OpenOrderFramework.Models;
using System.Data.Entity.Migrations;

namespace OpenOrderFramework.Migrations
{
    public class SeedItem
    {
        public List<RegularItem> List = new List<RegularItem> {
            new RegularItem { CatagorieID = 3, Name = "Ouroboros", ShortDescription = "Coral snake patterned prestige series snake whip.",
                Description = "One of our most advanced and stylish looking offerings in the Snake Whip catagory. This 6ft whip is 4 layers thick and features an exquisite pattern based off of a coral snake.",
                Price = 229.90m },
            new RegularItem { CatagorieID = 5, Name = "Stinger Bracelet", ShortDescription = "Fishy braided bracelet with the Stinger color pattern.",
                Description = "",
                Price = 15.00m },
            new RegularItem { CatagorieID = 5, Name = "Darkheart Bracelet", ShortDescription = "Fishy braided bracelet with the Darkheart color pattern.",
                Description = "",
                Price = 15.00m },
            new RegularItem { CatagorieID = 7, Name = "Darkheart Leash & Collar", ShortDescription = "Matching leash and collar combo braided in a Fishy with the Darkheart color pattern.",
                Description = "",
                Price = 49.50m },
            new RegularItem { CatagorieID = 5, Name = "T-Virus Bracelet", ShortDescription = "Infamous T-Virus bracelet. Feed your inner zombie!",
                Description = "",
                Price = 25.00m },
            new RegularItem { CatagorieID = 3, Name = "The Aprentance", ShortDescription = "Pitch black aprentance series Snake Whip.",
                Description = "Don't let the name fool you, this 6ft Snake Whip still packs plenty of punch! Excellent entry level whip for anyone just getting into whips and not ready to drop the cash on the more elite whips.",
                Price = 65.00m },
        };

        public void Seed(ApplicationDbContext context) {
            List.ForEach(f => context.Items.AddOrUpdate(f));
            context.SaveChanges();
        }
    }
}