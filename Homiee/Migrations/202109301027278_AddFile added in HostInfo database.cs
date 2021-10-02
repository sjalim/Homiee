namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileaddedinHostInfodatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HostInfoes", "AddFile", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HostInfoes", "AddFile");
        }
    }
}
