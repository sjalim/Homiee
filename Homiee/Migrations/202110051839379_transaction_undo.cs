namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transaction_undo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "Receiver_UserID", "dbo.Users");
            DropForeignKey("dbo.Transactions", "Sender_UserID", "dbo.Users");
            DropIndex("dbo.Transactions", new[] { "Receiver_UserID" });
            DropIndex("dbo.Transactions", new[] { "Sender_UserID" });
            AddColumn("dbo.Transactions", "SenderID", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "ReceiverID", c => c.Int(nullable: false));
            DropColumn("dbo.Transactions", "Receiver_UserID");
            DropColumn("dbo.Transactions", "Sender_UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "Sender_UserID", c => c.Int());
            AddColumn("dbo.Transactions", "Receiver_UserID", c => c.Int());
            DropColumn("dbo.Transactions", "ReceiverID");
            DropColumn("dbo.Transactions", "SenderID");
            CreateIndex("dbo.Transactions", "Sender_UserID");
            CreateIndex("dbo.Transactions", "Receiver_UserID");
            AddForeignKey("dbo.Transactions", "Sender_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Transactions", "Receiver_UserID", "dbo.Users", "UserID");
        }
    }
}
