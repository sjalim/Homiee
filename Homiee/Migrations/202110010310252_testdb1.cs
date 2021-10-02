namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testdb1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HostingInfoes",
                c => new
                    {
                        HostingInfoID = c.Int(nullable: false, identity: true),
                        Rooms = c.Int(nullable: false),
                        NumberRooms = c.Int(nullable: false),
                        NumberKitchens = c.Int(nullable: false),
                        NumberWashrooms = c.Int(nullable: false),
                        NumberBalconys = c.Int(nullable: false),
                        AdditionalFeaturess = c.String(nullable: false),
                        CountryNames = c.String(nullable: false),
                        StreetNames = c.String(nullable: false),
                        CityNames = c.String(nullable: false),
                        StateNames = c.String(nullable: false),
                        PostalCode = c.Int(nullable: false),
                        HostingRules = c.String(nullable: false),
                        MinimumStay = c.Int(nullable: false),
                        MaximumStay = c.Int(nullable: false),
                        Prices = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Offers = c.String(nullable: false),
                        RoomsCaption = c.String(nullable: false),
                        UserID_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.HostingInfoID)
                .ForeignKey("dbo.Users", t => t.UserID_UserID)
                .Index(t => t.UserID_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HostingInfoes", "UserID_UserID", "dbo.Users");
            DropIndex("dbo.HostingInfoes", new[] { "UserID_UserID" });
            DropTable("dbo.HostingInfoes");
        }
    }
}
