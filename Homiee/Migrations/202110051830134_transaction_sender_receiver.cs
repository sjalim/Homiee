namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transaction_sender_receiver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Receiver_UserID", c => c.Int());
            AddColumn("dbo.Transactions", "Sender_UserID", c => c.Int());
            CreateIndex("dbo.Transactions", "Receiver_UserID");
            CreateIndex("dbo.Transactions", "Sender_UserID");
            AddForeignKey("dbo.Transactions", "Receiver_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Transactions", "Sender_UserID", "dbo.Users", "UserID");
            DropColumn("dbo.Transactions", "SenderID");
            DropColumn("dbo.Transactions", "ReceiverID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "ReceiverID", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "SenderID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Transactions", "Sender_UserID", "dbo.Users");
            DropForeignKey("dbo.Transactions", "Receiver_UserID", "dbo.Users");
            DropIndex("dbo.Transactions", new[] { "Sender_UserID" });
            DropIndex("dbo.Transactions", new[] { "Receiver_UserID" });
            DropColumn("dbo.Transactions", "Sender_UserID");
            DropColumn("dbo.Transactions", "Receiver_UserID");
        }
    }
}
