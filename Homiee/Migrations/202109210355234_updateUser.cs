namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserProfilePicture", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserProfilePicture", c => c.Binary());
        }
    }
}
