namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hotelinfodbadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HotelInfoes",
                c => new
                    {
                        HotelInfoID = c.Int(nullable: false, identity: true),
                        HotelName = c.String(nullable: false),
                        HotelTradeLicence = c.String(nullable: false),
                        HotelRoomType = c.String(nullable: false),
                        NumBed = c.Int(nullable: false),
                        NumWash = c.Int(nullable: false),
                        AdditionalFeatures = c.String(nullable: false),
                        CountryName = c.String(nullable: false),
                        StreetName = c.String(nullable: false),
                        CityName = c.String(nullable: false),
                        StateName = c.String(nullable: false),
                        PostCode = c.Int(nullable: false),
                        HotelRules = c.String(nullable: false),
                        Cost = c.Double(nullable: false),
                        Offer = c.String(nullable: false),
                        AddFile = c.String(nullable: false),
                        HotelRoomCaption = c.String(nullable: false),
                        UserID_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.HotelInfoID)
                .ForeignKey("dbo.Users", t => t.UserID_UserID)
                .Index(t => t.UserID_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HotelInfoes", "UserID_UserID", "dbo.Users");
            DropIndex("dbo.HotelInfoes", new[] { "UserID_UserID" });
            DropTable("dbo.HotelInfoes");
        }
    }
}
