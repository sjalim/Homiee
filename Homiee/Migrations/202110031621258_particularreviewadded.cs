namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class particularreviewadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParticularHostRoomReviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        ReviewerID = c.Int(nullable: false),
                        ReviewedID = c.Int(nullable: false),
                        ReviewDescription = c.String(nullable: false),
                        HostPostInfo_HostPostInfoID = c.Int(),
                        User_UserID = c.Int(),
                        User1_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.HostPostInfoes", t => t.HostPostInfo_HostPostInfoID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .ForeignKey("dbo.Users", t => t.User1_UserID)
                .Index(t => t.HostPostInfo_HostPostInfoID)
                .Index(t => t.User_UserID)
                .Index(t => t.User1_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParticularHostRoomReviews", "User1_UserID", "dbo.Users");
            DropForeignKey("dbo.ParticularHostRoomReviews", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.ParticularHostRoomReviews", "HostPostInfo_HostPostInfoID", "dbo.HostPostInfoes");
            DropIndex("dbo.ParticularHostRoomReviews", new[] { "User1_UserID" });
            DropIndex("dbo.ParticularHostRoomReviews", new[] { "User_UserID" });
            DropIndex("dbo.ParticularHostRoomReviews", new[] { "HostPostInfo_HostPostInfoID" });
            DropTable("dbo.ParticularHostRoomReviews");
        }
    }
}
