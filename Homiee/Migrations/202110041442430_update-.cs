namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HostPostInfoes", "AdditionalFeatures", c => c.String());
            AlterColumn("dbo.HostPostInfoes", "CountryName", c => c.String());
            AlterColumn("dbo.HostPostInfoes", "StreetName", c => c.String());
            AlterColumn("dbo.HostPostInfoes", "CityName", c => c.String());
            AlterColumn("dbo.HostPostInfoes", "StateName", c => c.String());
            AlterColumn("dbo.HostPostInfoes", "HostRules", c => c.String());
            AlterColumn("dbo.HostPostInfoes", "Offer", c => c.String());
            AlterColumn("dbo.HostPostInfoes", "AddFile", c => c.String());
            AlterColumn("dbo.HostPostInfoes", "RoomCaption", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HostPostInfoes", "RoomCaption", c => c.String(nullable: false));
            AlterColumn("dbo.HostPostInfoes", "AddFile", c => c.String(nullable: false));
            AlterColumn("dbo.HostPostInfoes", "Offer", c => c.String(nullable: false));
            AlterColumn("dbo.HostPostInfoes", "HostRules", c => c.String(nullable: false));
            AlterColumn("dbo.HostPostInfoes", "StateName", c => c.String(nullable: false));
            AlterColumn("dbo.HostPostInfoes", "CityName", c => c.String(nullable: false));
            AlterColumn("dbo.HostPostInfoes", "StreetName", c => c.String(nullable: false));
            AlterColumn("dbo.HostPostInfoes", "CountryName", c => c.String(nullable: false));
            AlterColumn("dbo.HostPostInfoes", "AdditionalFeatures", c => c.String(nullable: false));
        }
    }
}
