namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatypechangeofRoom : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HostInfoes", "Room", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HostInfoes", "Room", c => c.Int(nullable: false));
        }
    }
}
