namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hostinfomodelchange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HostInfoes", "UserID_UserID", "dbo.Users");
            DropIndex("dbo.HostInfoes", new[] { "UserID_UserID" });
            CreateTable(
                "dbo.HostPostInfoes",
                c => new
                    {
                        HostPostInfoID = c.Int(nullable: false, identity: true),
                        Room = c.String(nullable: false),
                        NumRooms = c.Int(nullable: false),
                        NumKitchens = c.Int(nullable: false),
                        NumWash = c.Int(nullable: false),
                        NumBalconys = c.Int(nullable: false),
                        AdditionalFeatures = c.String(nullable: false),
                        CountryName = c.String(nullable: false),
                        StreetName = c.String(nullable: false),
                        CityName = c.String(nullable: false),
                        StateName = c.String(nullable: false),
                        PostCode = c.Int(nullable: false),
                        HostRules = c.String(nullable: false),
                        MinStay = c.Int(nullable: false),
                        MaxStay = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Offer = c.String(nullable: false),
                        AddFile = c.String(nullable: false),
                        RoomCaption = c.String(nullable: false),
                        UserID_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.HostPostInfoID)
                .ForeignKey("dbo.Users", t => t.UserID_UserID)
                .Index(t => t.UserID_UserID);
            
            DropTable("dbo.HostInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HostInfoes",
                c => new
                    {
                        HostInfoID = c.Int(nullable: false, identity: true),
                        Room = c.String(nullable: false),
                        NumRooms = c.Int(nullable: false),
                        NumKitchens = c.Int(nullable: false),
                        NumWash = c.Int(nullable: false),
                        NumBalconys = c.Int(nullable: false),
                        AdditionalFeatures = c.String(nullable: false),
                        CountryName = c.String(nullable: false),
                        StreetName = c.String(nullable: false),
                        CityName = c.String(nullable: false),
                        StateName = c.String(nullable: false),
                        PostCode = c.Int(nullable: false),
                        HostRules = c.String(nullable: false),
                        MinStay = c.Int(nullable: false),
                        MaxStay = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Offer = c.String(nullable: false),
                        AddFile = c.String(nullable: false),
                        RoomCaption = c.String(nullable: false),
                        UserID_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.HostInfoID);
            
            DropForeignKey("dbo.HostPostInfoes", "UserID_UserID", "dbo.Users");
            DropIndex("dbo.HostPostInfoes", new[] { "UserID_UserID" });
            DropTable("dbo.HostPostInfoes");
            CreateIndex("dbo.HostInfoes", "UserID_UserID");
            AddForeignKey("dbo.HostInfoes", "UserID_UserID", "dbo.Users", "UserID");
        }
    }
}
