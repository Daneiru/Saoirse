namespace OpenOrderFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixImageGroupLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "AvailableQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Images", "ImageGroupID", c => c.Int());
            CreateIndex("dbo.Images", "ImageGroupID");
            AddForeignKey("dbo.Images", "ImageGroupID", "dbo.ImageGroups", "ImageGroupID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "ImageGroupID", "dbo.ImageGroups");
            DropIndex("dbo.Images", new[] { "ImageGroupID" });
            DropColumn("dbo.Images", "ImageGroupID");
            DropColumn("dbo.Items", "AvailableQuantity");
        }
    }
}
