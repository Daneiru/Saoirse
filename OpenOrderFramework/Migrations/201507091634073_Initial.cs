namespace OpenOrderFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        ItemId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 160),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pounds = c.Int(nullable: false),
                        Ounces = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        ImageGroupID = c.Int(),
                        DesignerCatagorieID = c.Int(),
                        CatagorieID = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        DesignerCatagorie_DesignerCatagorieID = c.Int(),
                        Catagorie_CatagorieID = c.Int(),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.ImageGroups", t => t.ImageGroupID)
                .ForeignKey("dbo.DesignerCatagories", t => t.DesignerCatagorie_DesignerCatagorieID)
                .ForeignKey("dbo.DesignerCatagories", t => t.DesignerCatagorieID)
                .ForeignKey("dbo.Catagories", t => t.Catagorie_CatagorieID)
                .ForeignKey("dbo.Catagories", t => t.CatagorieID)
                .Index(t => t.ImageGroupID)
                .Index(t => t.DesignerCatagorieID)
                .Index(t => t.CatagorieID)
                .Index(t => t.DesignerCatagorie_DesignerCatagorieID)
                .Index(t => t.Catagorie_CatagorieID);
            
            CreateTable(
                "dbo.ImageGroups",
                c => new
                    {
                        ImageGroupID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 160),
                    })
                .PrimaryKey(t => t.ImageGroupID);
            
            CreateTable(
                "dbo.DesignerCatagories",
                c => new
                    {
                        DesignerCatagorieID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SortOrder = c.Int(nullable: false),
                        ParentID = c.Int(),
                    })
                .PrimaryKey(t => t.DesignerCatagorieID)
                .ForeignKey("dbo.DesignerCatagories", t => t.ParentID)
                .Index(t => t.ParentID);
            
            CreateTable(
                "dbo.DesignerItemOptionSets",
                c => new
                    {
                        DesignerItemOptionSetID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 160),
                        Description = c.String(),
                        ItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DesignerItemOptionSetID)
                .ForeignKey("dbo.Items", t => t.ItemID)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.DesignerOptions",
                c => new
                    {
                        DesignerOptionID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 160),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pounds = c.Int(nullable: false),
                        Ounces = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        ImageGroupID = c.Int(nullable: false),
                        DesignerItemOptionSetID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DesignerOptionID)
                .ForeignKey("dbo.DesignerItemOptionSets", t => t.DesignerItemOptionSetID)
                .ForeignKey("dbo.ImageGroups", t => t.ImageGroupID)
                .Index(t => t.ImageGroupID)
                .Index(t => t.DesignerItemOptionSetID);
            
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        CatagorieID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SortOrder = c.Int(nullable: false),
                        ParentID = c.Int(),
                    })
                .PrimaryKey(t => t.CatagorieID)
                .ForeignKey("dbo.Catagories", t => t.ParentID)
                .Index(t => t.ParentID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailID)
                .ForeignKey("dbo.Items", t => t.ItemID)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .Index(t => t.ItemID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.DesignerItemSelections",
                c => new
                    {
                        DesignerItemSelectionID = c.Int(nullable: false, identity: true),
                        OrderDetailID = c.Int(nullable: false),
                        DesignerOptionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DesignerItemSelectionID)
                .ForeignKey("dbo.DesignerOptions", t => t.DesignerOptionID)
                .ForeignKey("dbo.OrderDetails", t => t.OrderDetailID)
                .Index(t => t.OrderDetailID)
                .Index(t => t.DesignerOptionID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                        TrackingNumber = c.String(),
                        Username = c.String(),
                        Comments = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 160),
                        LastName = c.String(nullable: false, maxLength: 160),
                        Address = c.String(nullable: false, maxLength: 70),
                        City = c.String(nullable: false, maxLength: 40),
                        State = c.String(nullable: false, maxLength: 40),
                        PostalCode = c.String(nullable: false, maxLength: 10),
                        Country = c.String(nullable: false, maxLength: 40),
                        Phone = c.String(nullable: false, maxLength: 24),
                        Experation = c.DateTime(nullable: false),
                        SaveInfo = c.Boolean(nullable: false),
                        Email = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShippingCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 160),
                        Caption = c.String(),
                        InternalImage = c.Binary(),
                        ItemPictureUrl = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.ImageID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Carts", "ItemId", "dbo.Items");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "ItemID", "dbo.Items");
            DropForeignKey("dbo.DesignerItemSelections", "OrderDetailID", "dbo.OrderDetails");
            DropForeignKey("dbo.DesignerItemSelections", "DesignerOptionID", "dbo.DesignerOptions");
            DropForeignKey("dbo.Items", "CatagorieID", "dbo.Catagories");
            DropForeignKey("dbo.Catagories", "ParentID", "dbo.Catagories");
            DropForeignKey("dbo.Items", "Catagorie_CatagorieID", "dbo.Catagories");
            DropForeignKey("dbo.DesignerItemOptionSets", "ItemID", "dbo.Items");
            DropForeignKey("dbo.DesignerOptions", "ImageGroupID", "dbo.ImageGroups");
            DropForeignKey("dbo.DesignerOptions", "DesignerItemOptionSetID", "dbo.DesignerItemOptionSets");
            DropForeignKey("dbo.Items", "DesignerCatagorieID", "dbo.DesignerCatagories");
            DropForeignKey("dbo.DesignerCatagories", "ParentID", "dbo.DesignerCatagories");
            DropForeignKey("dbo.Items", "DesignerCatagorie_DesignerCatagorieID", "dbo.DesignerCatagories");
            DropForeignKey("dbo.Items", "ImageGroupID", "dbo.ImageGroups");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.DesignerItemSelections", new[] { "DesignerOptionID" });
            DropIndex("dbo.DesignerItemSelections", new[] { "OrderDetailID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.OrderDetails", new[] { "ItemID" });
            DropIndex("dbo.Catagories", new[] { "ParentID" });
            DropIndex("dbo.DesignerOptions", new[] { "DesignerItemOptionSetID" });
            DropIndex("dbo.DesignerOptions", new[] { "ImageGroupID" });
            DropIndex("dbo.DesignerItemOptionSets", new[] { "ItemID" });
            DropIndex("dbo.DesignerCatagories", new[] { "ParentID" });
            DropIndex("dbo.Items", new[] { "Catagorie_CatagorieID" });
            DropIndex("dbo.Items", new[] { "DesignerCatagorie_DesignerCatagorieID" });
            DropIndex("dbo.Items", new[] { "CatagorieID" });
            DropIndex("dbo.Items", new[] { "DesignerCatagorieID" });
            DropIndex("dbo.Items", new[] { "ImageGroupID" });
            DropIndex("dbo.Carts", new[] { "ItemId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Images");
            DropTable("dbo.Orders");
            DropTable("dbo.DesignerItemSelections");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Catagories");
            DropTable("dbo.DesignerOptions");
            DropTable("dbo.DesignerItemOptionSets");
            DropTable("dbo.DesignerCatagories");
            DropTable("dbo.ImageGroups");
            DropTable("dbo.Items");
            DropTable("dbo.Carts");
        }
    }
}
