namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HostInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HostInfoes",
                c => new
                    {
                        HostInfoID = c.Int(nullable: false, identity: true),
                        Room = c.String(),
                        NumRooms = c.String(),
                        NumKitchens = c.String(),
                        NumWash = c.String(),
                        NumBalconys = c.String(),
                        AdditionalFeatures = c.String(),
                        CountryName = c.String(),
                        StreetName = c.String(),
                        CityName = c.String(),
                        StateName = c.String(),
                        PostCode = c.String(),
                        HostRules = c.String(),
                        MinStay = c.String(),
                        MaxStay = c.String(),
                        Price = c.String(),
                        Offer = c.String(),
                        RoomCaption = c.String(),
                        AddFile = c.Binary(),
                    })
                .PrimaryKey(t => t.HostInfoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HostInfoes");
        }
    }
}
