namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkissue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GuestsToHostsReviews", "ReviewDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GuestsToHostsReviews", "ReviewDescription", c => c.String());
        }
    }
}
