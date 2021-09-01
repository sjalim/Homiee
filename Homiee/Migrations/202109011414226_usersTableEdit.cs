namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usersTableEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserRegistrationDate", c => c.DateTime());
            DropColumn("dbo.Users", "UserAddressID");
            DropColumn("dbo.Users", "UserRegistrationData");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserRegistrationData", c => c.DateTime());
            AddColumn("dbo.Users", "UserAddressID", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "UserRegistrationDate");
        }
    }
}
