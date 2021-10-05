namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatime_update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notifications", "NotifyTime", c => c.DateTime());
            AlterColumn("dbo.Reservations", "CheckIn", c => c.DateTime());
            AlterColumn("dbo.Reservations", "CheckOut", c => c.DateTime());
            AlterColumn("dbo.Reservations", "ReserveTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "ReserveTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Reservations", "CheckOut", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Reservations", "CheckIn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Notifications", "NotifyTime", c => c.DateTime(nullable: false));
        }
    }
}
