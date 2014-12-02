namespace Sherlock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class constrains : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ApartmentID = c.Int(nullable: false),
                        BuildingNumber = c.Int(nullable: false),
                        AptNumber = c.Int(),
                        StreetID = c.Int(nullable: false),
                        City_CityID = c.Int(),
                    })
                .PrimaryKey(t => t.ApartmentID)
                .ForeignKey("dbo.Apartments", t => t.ApartmentID)
                .ForeignKey("dbo.Cities", t => t.City_CityID)
                .ForeignKey("dbo.Streets", t => t.StreetID, cascadeDelete: true)
                .Index(t => t.ApartmentID)
                .Index(t => t.StreetID)
                .Index(t => t.City_CityID);
            
            CreateTable(
                "dbo.Apartments",
                c => new
                    {
                        ApartmentID = c.Int(nullable: false, identity: true),
                        Rooms = c.Single(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Area = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ApartmentID);
            
            CreateTable(
                "dbo.Streets",
                c => new
                    {
                        StreetID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EnglishName = c.String(),
                        CityID = c.Int(),
                    })
                .PrimaryKey(t => t.StreetID)
                .ForeignKey("dbo.Cities", t => t.CityID)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DitrictID = c.Int(),
                        Ditrict_DistrictID = c.Int(),
                    })
                .PrimaryKey(t => t.CityID)
                .ForeignKey("dbo.Districts", t => t.Ditrict_DistrictID)
                .Index(t => t.Ditrict_DistrictID);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        DistrictID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DistrictID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "StreetID", "dbo.Streets");
            DropForeignKey("dbo.Streets", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Cities", "Ditrict_DistrictID", "dbo.Districts");
            DropForeignKey("dbo.Addresses", "City_CityID", "dbo.Cities");
            DropForeignKey("dbo.Addresses", "ApartmentID", "dbo.Apartments");
            DropIndex("dbo.Cities", new[] { "Ditrict_DistrictID" });
            DropIndex("dbo.Streets", new[] { "CityID" });
            DropIndex("dbo.Addresses", new[] { "City_CityID" });
            DropIndex("dbo.Addresses", new[] { "StreetID" });
            DropIndex("dbo.Addresses", new[] { "ApartmentID" });
            DropTable("dbo.Districts");
            DropTable("dbo.Cities");
            DropTable("dbo.Streets");
            DropTable("dbo.Apartments");
            DropTable("dbo.Addresses");
        }
    }
}
