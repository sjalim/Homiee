namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HostPosts : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.HostPostInfoes", name: "UserID_UserID", newName: "User_UserID");
            RenameIndex(table: "dbo.HostPostInfoes", name: "IX_UserID_UserID", newName: "IX_User_UserID");
            CreateTable(
                "dbo.HostOfficePosts",
                c => new
                    {
                        HostOfficePostID = c.Int(nullable: false, identity: true),
                        SpaceSize = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        PaymentType = c.Int(nullable: false),
                        Offer = c.String(),
                        AddFile = c.String(),
                        RoomCaption = c.String(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.HostOfficePostID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            AddColumn("dbo.HostPostInfoes", "PaymentType", c => c.Int(nullable: false));
            AlterColumn("dbo.HostPostInfoes", "Room", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HostOfficePosts", "User_UserID", "dbo.Users");
            DropIndex("dbo.HostOfficePosts", new[] { "User_UserID" });
            AlterColumn("dbo.HostPostInfoes", "Room", c => c.String(nullable: false));
            DropColumn("dbo.HostPostInfoes", "PaymentType");
            DropTable("dbo.HostOfficePosts");
            RenameIndex(table: "dbo.HostPostInfoes", name: "IX_User_UserID", newName: "IX_UserID_UserID");
            RenameColumn(table: "dbo.HostPostInfoes", name: "User_UserID", newName: "UserID_UserID");
        }
    }
}
