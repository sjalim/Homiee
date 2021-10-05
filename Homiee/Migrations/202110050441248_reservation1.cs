namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reservation1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Post_HostPostInfoID", c => c.Int());
            CreateIndex("dbo.Reservations", "Post_HostPostInfoID");
            AddForeignKey("dbo.Reservations", "Post_HostPostInfoID", "dbo.HostPostInfoes", "HostPostInfoID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "Post_HostPostInfoID", "dbo.HostPostInfoes");
            DropIndex("dbo.Reservations", new[] { "Post_HostPostInfoID" });
            DropColumn("dbo.Reservations", "Post_HostPostInfoID");
        }
    }
}
