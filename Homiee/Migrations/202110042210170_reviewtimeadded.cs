namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reviewtimeadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HostsToGuestsReviews", "ReviewTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HostsToGuestsReviews", "ReviewTime");
        }
    }
}
