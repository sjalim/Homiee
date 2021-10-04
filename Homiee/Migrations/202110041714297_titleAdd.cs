namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class titleAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HostOfficePosts", "Title", c => c.String());
            AddColumn("dbo.HostPostInfoes", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HostPostInfoes", "Title");
            DropColumn("dbo.HostOfficePosts", "Title");
        }
    }
}
