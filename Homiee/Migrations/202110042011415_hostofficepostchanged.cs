namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hostofficepostchanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HostOfficePosts", "NumRooms", c => c.Int(nullable: false));
            AddColumn("dbo.HostOfficePosts", "NumWash", c => c.Int(nullable: false));
            AddColumn("dbo.HostOfficePosts", "NumBalconys", c => c.Int(nullable: false));
            AddColumn("dbo.HostOfficePosts", "AdditionalFeatures", c => c.String());
            AddColumn("dbo.HostOfficePosts", "CountryName", c => c.String());
            AddColumn("dbo.HostOfficePosts", "StreetName", c => c.String());
            AddColumn("dbo.HostOfficePosts", "CityName", c => c.String());
            AddColumn("dbo.HostOfficePosts", "StateName", c => c.String());
            AddColumn("dbo.HostOfficePosts", "PostCode", c => c.Int(nullable: false));
            AddColumn("dbo.HostOfficePosts", "HostRules", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HostOfficePosts", "HostRules");
            DropColumn("dbo.HostOfficePosts", "PostCode");
            DropColumn("dbo.HostOfficePosts", "StateName");
            DropColumn("dbo.HostOfficePosts", "CityName");
            DropColumn("dbo.HostOfficePosts", "StreetName");
            DropColumn("dbo.HostOfficePosts", "CountryName");
            DropColumn("dbo.HostOfficePosts", "AdditionalFeatures");
            DropColumn("dbo.HostOfficePosts", "NumBalconys");
            DropColumn("dbo.HostOfficePosts", "NumWash");
            DropColumn("dbo.HostOfficePosts", "NumRooms");
        }
    }
}
