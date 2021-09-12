namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addModals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        BankID = c.Int(nullable: false, identity: true),
                        BankAccountHolderID = c.Int(nullable: false),
                        BankAccountNumber = c.String(),
                        BankName = c.String(),
                        BankRoutingNumber = c.String(),
                        BankingNumber = c.String(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.BankID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        ChatID = c.Int(nullable: false, identity: true),
                        ChatSenderID = c.Int(),
                        ChatReceiverID = c.Int(),
                        ChatMessage = c.String(),
                        User_UserID = c.Int(),
                        User1_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ChatID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .ForeignKey("dbo.Users", t => t.User1_UserID)
                .Index(t => t.User_UserID)
                .Index(t => t.User1_UserID);
            
            CreateTable(
                "dbo.GuestsToHostsReviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        ReviewerID = c.Int(nullable: false),
                        ReviewedID = c.Int(nullable: false),
                        ReviewDescription = c.String(),
                        User_UserID = c.Int(),
                        User1_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .ForeignKey("dbo.Users", t => t.User1_UserID)
                .Index(t => t.User_UserID)
                .Index(t => t.User1_UserID);
            
            CreateTable(
                "dbo.GuestsToHotelsReviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        ReviewerID = c.Int(nullable: false),
                        ReviewedID = c.Int(nullable: false),
                        ReviewDescription = c.String(),
                        Hotel_HotelID = c.Int(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Hotels", t => t.Hotel_HotelID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.Hotel_HotelID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        HotelID = c.Int(nullable: false, identity: true),
                        HotelManager = c.String(),
                        HotelName = c.String(),
                        HoteManagerPhone = c.String(),
                        HotelLanLine = c.String(),
                        HotelEmail = c.String(),
                        HotelPassword = c.String(),
                        HotelTradeLicenseNo = c.String(),
                        HotelPictures = c.Binary(),
                        HotelRegistrationData = c.DateTime(),
                        HotelAddressID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HotelID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        PostOwnerID = c.Int(nullable: false),
                        PostOwnerType = c.String(),
                        PostDescription = c.String(),
                        PostImages = c.Binary(),
                        PostDate = c.DateTime(),
                        Hotel_HotelID = c.Int(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.Hotels", t => t.Hotel_HotelID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.Hotel_HotelID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.PostComments",
                c => new
                    {
                        PostCommentID = c.Int(nullable: false, identity: true),
                        PostID = c.Int(nullable: false),
                        PostCommenterID = c.Int(nullable: false),
                        PostComment1 = c.String(),
                    })
                .PrimaryKey(t => t.PostCommentID)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.HostsToGuestsReviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        ReviewerID = c.Int(nullable: false),
                        ReviewedID = c.Int(nullable: false),
                        ReviewDescription = c.String(),
                        User_UserID = c.Int(),
                        User1_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .ForeignKey("dbo.Users", t => t.User1_UserID)
                .Index(t => t.User_UserID)
                .Index(t => t.User1_UserID);
            
            CreateTable(
                "dbo.MobileBankings",
                c => new
                    {
                        MobileBankingID = c.Int(nullable: false, identity: true),
                        MobileBankingAccountHolderID = c.Int(nullable: false),
                        MobileBankingAccountNumber = c.String(),
                        MobileBankingAccountType = c.String(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.MobileBankingID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingID = c.Int(nullable: false, identity: true),
                        RatingHolderID = c.Int(),
                        RatingHonesty = c.Int(),
                        RatingKindness = c.Int(),
                        RatingServices = c.Int(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.RatingID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.UserComments",
                c => new
                    {
                        UserCommentID = c.Int(nullable: false, identity: true),
                        UserCommenterID = c.Int(nullable: false),
                        UserCommentOnID = c.Int(nullable: false),
                        UserComment1 = c.String(),
                        User_UserID = c.Int(),
                        User1_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.UserCommentID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .ForeignKey("dbo.Users", t => t.User1_UserID)
                .Index(t => t.User_UserID)
                .Index(t => t.User1_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserComments", "User1_UserID", "dbo.Users");
            DropForeignKey("dbo.UserComments", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Ratings", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.MobileBankings", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.HostsToGuestsReviews", "User1_UserID", "dbo.Users");
            DropForeignKey("dbo.HostsToGuestsReviews", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.GuestsToHotelsReviews", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Posts", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.PostComments", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Posts", "Hotel_HotelID", "dbo.Hotels");
            DropForeignKey("dbo.GuestsToHotelsReviews", "Hotel_HotelID", "dbo.Hotels");
            DropForeignKey("dbo.GuestsToHostsReviews", "User1_UserID", "dbo.Users");
            DropForeignKey("dbo.GuestsToHostsReviews", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Chats", "User1_UserID", "dbo.Users");
            DropForeignKey("dbo.Chats", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Banks", "User_UserID", "dbo.Users");
            DropIndex("dbo.UserComments", new[] { "User1_UserID" });
            DropIndex("dbo.UserComments", new[] { "User_UserID" });
            DropIndex("dbo.Ratings", new[] { "User_UserID" });
            DropIndex("dbo.MobileBankings", new[] { "User_UserID" });
            DropIndex("dbo.HostsToGuestsReviews", new[] { "User1_UserID" });
            DropIndex("dbo.HostsToGuestsReviews", new[] { "User_UserID" });
            DropIndex("dbo.PostComments", new[] { "PostID" });
            DropIndex("dbo.Posts", new[] { "User_UserID" });
            DropIndex("dbo.Posts", new[] { "Hotel_HotelID" });
            DropIndex("dbo.GuestsToHotelsReviews", new[] { "User_UserID" });
            DropIndex("dbo.GuestsToHotelsReviews", new[] { "Hotel_HotelID" });
            DropIndex("dbo.GuestsToHostsReviews", new[] { "User1_UserID" });
            DropIndex("dbo.GuestsToHostsReviews", new[] { "User_UserID" });
            DropIndex("dbo.Chats", new[] { "User1_UserID" });
            DropIndex("dbo.Chats", new[] { "User_UserID" });
            DropIndex("dbo.Banks", new[] { "User_UserID" });
            DropTable("dbo.UserComments");
            DropTable("dbo.Ratings");
            DropTable("dbo.MobileBankings");
            DropTable("dbo.HostsToGuestsReviews");
            DropTable("dbo.PostComments");
            DropTable("dbo.Posts");
            DropTable("dbo.Hotels");
            DropTable("dbo.GuestsToHotelsReviews");
            DropTable("dbo.GuestsToHostsReviews");
            DropTable("dbo.Chats");
            DropTable("dbo.Banks");
        }
    }
}
