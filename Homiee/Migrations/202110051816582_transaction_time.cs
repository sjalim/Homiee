namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transaction_time : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "TransactionTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "TransactionTime");
        }
    }
}
