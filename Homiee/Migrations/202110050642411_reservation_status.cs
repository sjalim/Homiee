namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reservation_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "Status");
        }
    }
}
