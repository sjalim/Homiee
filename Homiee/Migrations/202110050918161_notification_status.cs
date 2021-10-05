namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notification_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "SeenStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "SeenStatus");
        }
    }
}
