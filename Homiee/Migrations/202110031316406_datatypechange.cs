namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatypechange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HostPostInfoes", "Room", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HostPostInfoes", "Room", c => c.String(nullable: false));
        }
    }
}
