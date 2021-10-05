namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotificationType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "NotificationType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "NotificationType");
        }
    }
}
