namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checking : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HostInfoes", "Room", c => c.String(nullable: false));
            AlterColumn("dbo.HostInfoes", "AdditionalFeatures", c => c.String(nullable: false));
            AlterColumn("dbo.HostInfoes", "CountryName", c => c.String(nullable: false));
            AlterColumn("dbo.HostInfoes", "StreetName", c => c.String(nullable: false));
            AlterColumn("dbo.HostInfoes", "CityName", c => c.String(nullable: false));
            AlterColumn("dbo.HostInfoes", "StateName", c => c.String(nullable: false));
            AlterColumn("dbo.HostInfoes", "HostRules", c => c.String(nullable: false));
            AlterColumn("dbo.HostInfoes", "Offer", c => c.String(nullable: false));
            AlterColumn("dbo.HostInfoes", "RoomCaption", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HostInfoes", "RoomCaption", c => c.String());
            AlterColumn("dbo.HostInfoes", "Offer", c => c.String());
            AlterColumn("dbo.HostInfoes", "HostRules", c => c.String());
            AlterColumn("dbo.HostInfoes", "StateName", c => c.String());
            AlterColumn("dbo.HostInfoes", "CityName", c => c.String());
            AlterColumn("dbo.HostInfoes", "StreetName", c => c.String());
            AlterColumn("dbo.HostInfoes", "CountryName", c => c.String());
            AlterColumn("dbo.HostInfoes", "AdditionalFeatures", c => c.String());
            AlterColumn("dbo.HostInfoes", "Room", c => c.String());
        }
    }
}
