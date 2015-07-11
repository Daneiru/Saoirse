namespace OpenOrderFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemShortDesc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "ShortDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "ShortDescription");
        }
    }
}
