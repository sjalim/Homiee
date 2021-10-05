namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notification_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "Renter_UserID", c => c.Int());
            CreateIndex("dbo.Notifications", "Renter_UserID");
            AddForeignKey("dbo.Notifications", "Renter_UserID", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "Renter_UserID", "dbo.Users");
            DropIndex("dbo.Notifications", new[] { "Renter_UserID" });
            DropColumn("dbo.Notifications", "Renter_UserID");
        }
    }
}
