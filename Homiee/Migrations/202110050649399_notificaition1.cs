namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notificaition1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificaitonID = c.Int(nullable: false, identity: true),
                        NotifyText = c.String(),
                        NotifyTime = c.DateTime(nullable: false),
                        Post_HostPostInfoID = c.Int(),
                        Reserver_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.NotificaitonID)
                .ForeignKey("dbo.HostPostInfoes", t => t.Post_HostPostInfoID)
                .ForeignKey("dbo.Users", t => t.Reserver_UserID)
                .Index(t => t.Post_HostPostInfoID)
                .Index(t => t.Reserver_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "Reserver_UserID", "dbo.Users");
            DropForeignKey("dbo.Notifications", "Post_HostPostInfoID", "dbo.HostPostInfoes");
            DropIndex("dbo.Notifications", new[] { "Reserver_UserID" });
            DropIndex("dbo.Notifications", new[] { "Post_HostPostInfoID" });
            DropTable("dbo.Notifications");
        }
    }
}
