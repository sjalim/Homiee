namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HostInfo1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HostInfoes", "UserID_UserID", c => c.Int());
            AlterColumn("dbo.HostInfoes", "Room", c => c.Int(nullable: false));
            AlterColumn("dbo.HostInfoes", "NumRooms", c => c.Int(nullable: false));
            AlterColumn("dbo.HostInfoes", "NumKitchens", c => c.Int(nullable: false));
            AlterColumn("dbo.HostInfoes", "NumWash", c => c.Int(nullable: false));
            AlterColumn("dbo.HostInfoes", "NumBalconys", c => c.Int(nullable: false));
            AlterColumn("dbo.HostInfoes", "PostCode", c => c.Int(nullable: false));
            AlterColumn("dbo.HostInfoes", "MinStay", c => c.Int(nullable: false));
            AlterColumn("dbo.HostInfoes", "MaxStay", c => c.Int(nullable: false));
            AlterColumn("dbo.HostInfoes", "Price", c => c.Double(nullable: false));
            CreateIndex("dbo.HostInfoes", "UserID_UserID");
            AddForeignKey("dbo.HostInfoes", "UserID_UserID", "dbo.Users", "UserID");
            DropColumn("dbo.HostInfoes", "AddFile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HostInfoes", "AddFile", c => c.Binary());
            DropForeignKey("dbo.HostInfoes", "UserID_UserID", "dbo.Users");
            DropIndex("dbo.HostInfoes", new[] { "UserID_UserID" });
            AlterColumn("dbo.HostInfoes", "Price", c => c.String());
            AlterColumn("dbo.HostInfoes", "MaxStay", c => c.String());
            AlterColumn("dbo.HostInfoes", "MinStay", c => c.String());
            AlterColumn("dbo.HostInfoes", "PostCode", c => c.String());
            AlterColumn("dbo.HostInfoes", "NumBalconys", c => c.String());
            AlterColumn("dbo.HostInfoes", "NumWash", c => c.String());
            AlterColumn("dbo.HostInfoes", "NumKitchens", c => c.String());
            AlterColumn("dbo.HostInfoes", "NumRooms", c => c.String());
            AlterColumn("dbo.HostInfoes", "Room", c => c.String());
            DropColumn("dbo.HostInfoes", "UserID_UserID");
        }
    }
}
