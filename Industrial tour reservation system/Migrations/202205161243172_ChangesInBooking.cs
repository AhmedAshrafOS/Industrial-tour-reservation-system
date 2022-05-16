namespace Industrial_tour_reservation_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInBooking : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "VisitorID", "dbo.Visitors");
            DropIndex("dbo.Bookings", new[] { "VisitorID" });
            RenameColumn(table: "dbo.Bookings", name: "VisitorID", newName: "Visitor_VisitorID");
            CreateTable(
                "dbo.VisitorBookings",
                c => new
                    {
                        VisitorID = c.Int(nullable: false),
                        PackageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VisitorID, t.PackageID })
                .ForeignKey("dbo.Packages", t => t.PackageID, cascadeDelete: true)
                .ForeignKey("dbo.Visitors", t => t.VisitorID, cascadeDelete: true)
                .Index(t => t.VisitorID)
                .Index(t => t.PackageID);
            
            AddColumn("dbo.Bookings", "NameOfVisitor", c => c.String());
            AddColumn("dbo.Bookings", "NameOfPackage", c => c.String());
            AddColumn("dbo.Bookings", "NameOfPlace", c => c.String());
            AddColumn("dbo.Bookings", "PackgeDetails_PackageID", c => c.Int());
            AlterColumn("dbo.Bookings", "Visitor_VisitorID", c => c.Int());
            CreateIndex("dbo.Bookings", "Visitor_VisitorID");
            CreateIndex("dbo.Bookings", "PackgeDetails_PackageID");
            AddForeignKey("dbo.Bookings", "PackgeDetails_PackageID", "dbo.Packages", "PackageID");
            AddForeignKey("dbo.Bookings", "Visitor_VisitorID", "dbo.Visitors", "VisitorID");
            DropColumn("dbo.Bookings", "BookingName");
            DropColumn("dbo.Bookings", "TotalCost");
            DropColumn("dbo.Bookings", "NumOfVistors");
            DropColumn("dbo.Bookings", "Year");
            DropColumn("dbo.Bookings", "Month");
            DropColumn("dbo.Bookings", "Day");
            DropColumn("dbo.Bookings", "Hour");
            DropColumn("dbo.Bookings", "Minuit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "Minuit", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "Hour", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "Day", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "Month", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "NumOfVistors", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "TotalCost", c => c.Single(nullable: false));
            AddColumn("dbo.Bookings", "BookingName", c => c.String(nullable: false));
            DropForeignKey("dbo.Bookings", "Visitor_VisitorID", "dbo.Visitors");
            DropForeignKey("dbo.Bookings", "PackgeDetails_PackageID", "dbo.Packages");
            DropForeignKey("dbo.VisitorBookings", "VisitorID", "dbo.Visitors");
            DropForeignKey("dbo.VisitorBookings", "PackageID", "dbo.Packages");
            DropIndex("dbo.VisitorBookings", new[] { "PackageID" });
            DropIndex("dbo.VisitorBookings", new[] { "VisitorID" });
            DropIndex("dbo.Bookings", new[] { "PackgeDetails_PackageID" });
            DropIndex("dbo.Bookings", new[] { "Visitor_VisitorID" });
            AlterColumn("dbo.Bookings", "Visitor_VisitorID", c => c.Int(nullable: false));
            DropColumn("dbo.Bookings", "PackgeDetails_PackageID");
            DropColumn("dbo.Bookings", "NameOfPlace");
            DropColumn("dbo.Bookings", "NameOfPackage");
            DropColumn("dbo.Bookings", "NameOfVisitor");
            DropTable("dbo.VisitorBookings");
            RenameColumn(table: "dbo.Bookings", name: "Visitor_VisitorID", newName: "VisitorID");
            CreateIndex("dbo.Bookings", "VisitorID");
            AddForeignKey("dbo.Bookings", "VisitorID", "dbo.Visitors", "VisitorID", cascadeDelete: true);
        }
    }
}
