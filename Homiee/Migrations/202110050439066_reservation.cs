namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reservation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationID = c.Int(nullable: false, identity: true),
                        CheckIn = c.DateTime(nullable: false),
                        CheckOut = c.DateTime(nullable: false),
                        ReserveTime = c.DateTime(nullable: false),
                        Renter_UserID = c.Int(),
                        Reserver_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ReservationID)
                .ForeignKey("dbo.Users", t => t.Renter_UserID)
                .ForeignKey("dbo.Users", t => t.Reserver_UserID)
                .Index(t => t.Renter_UserID)
                .Index(t => t.Reserver_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "Reserver_UserID", "dbo.Users");
            DropForeignKey("dbo.Reservations", "Renter_UserID", "dbo.Users");
            DropIndex("dbo.Reservations", new[] { "Reserver_UserID" });
            DropIndex("dbo.Reservations", new[] { "Renter_UserID" });
            DropTable("dbo.Reservations");
        }
    }
}
