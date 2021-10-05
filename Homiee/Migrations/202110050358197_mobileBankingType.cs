namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mobileBankingType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MobileBankings", "MobileBankingAccountType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MobileBankings", "MobileBankingAccountType", c => c.String());
        }
    }
}
