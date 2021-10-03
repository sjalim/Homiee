namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactiontable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        TransactionType = c.Int(nullable: false),
                        SenderID = c.Int(nullable: false),
                        ReceiverID = c.Int(nullable: false),
                        SenderAccountNumber = c.String(),
                        ReceiverAccountNumber = c.String(),
                        TxID = c.String(),
                    })
                .PrimaryKey(t => t.TransactionID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transactions");
        }
    }
}
