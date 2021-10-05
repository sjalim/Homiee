namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notification_reservation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "Reservation_ReservationID", c => c.Int());
            CreateIndex("dbo.Notifications", "Reservation_ReservationID");
            AddForeignKey("dbo.Notifications", "Reservation_ReservationID", "dbo.Reservations", "ReservationID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "Reservation_ReservationID", "dbo.Reservations");
            DropIndex("dbo.Notifications", new[] { "Reservation_ReservationID" });
            DropColumn("dbo.Notifications", "Reservation_ReservationID");
        }
    }
}
