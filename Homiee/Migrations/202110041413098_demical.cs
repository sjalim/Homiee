namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class demical : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HostPostInfoes", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HostPostInfoes", "Price", c => c.Double(nullable: false));
        }
    }
}
