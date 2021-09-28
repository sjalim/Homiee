namespace Homiee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BecomeHost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HotelAddresses",
                c => new
                    {
                        HotelAddressID = c.Int(nullable: false, identity: true),
                        AddressCountry = c.String(),
                        AddressDivision = c.String(),
                        AddressCity = c.String(),
                        AddressArea = c.String(),
                        AddressExtension = c.String(),
                    })
                .PrimaryKey(t => t.HotelAddressID);
            
            AddColumn("dbo.Hotels", "HotelRegistrationDate", c => c.DateTime());
            AlterColumn("dbo.Hotels", "HotelPictures", c => c.String());
            AlterColumn("dbo.Hotels", "HotelAddressID", c => c.Int());
            CreateIndex("dbo.Hotels", "HotelAddressID");
            AddForeignKey("dbo.Hotels", "HotelAddressID", "dbo.HotelAddresses", "HotelAddressID");
            DropColumn("dbo.Hotels", "HotelRegistrationData");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hotels", "HotelRegistrationData", c => c.DateTime());
            DropForeignKey("dbo.Hotels", "HotelAddressID", "dbo.HotelAddresses");
            DropIndex("dbo.Hotels", new[] { "HotelAddressID" });
            AlterColumn("dbo.Hotels", "HotelAddressID", c => c.Int(nullable: false));
            AlterColumn("dbo.Hotels", "HotelPictures", c => c.Binary());
            DropColumn("dbo.Hotels", "HotelRegistrationDate");
            DropTable("dbo.HotelAddresses");
        }
    }
}
