namespace Industrial_tour_reservation_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInBookingPart2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "PackgeDetails_PackageID", "dbo.Packages");
            DropForeignKey("dbo.Bookings", "Visitor_VisitorID", "dbo.Visitors");
            DropIndex("dbo.Bookings", new[] { "Visitor_VisitorID" });
            DropIndex("dbo.Bookings", new[] { "PackgeDetails_PackageID" });
            RenameColumn(table: "dbo.Bookings", name: "Visitor_VisitorID", newName: "VisitorID");
            AddColumn("dbo.Bookings", "PackageID", c => c.Int(nullable: true));
            AlterColumn("dbo.Bookings", "VisitorID", c => c.Int(nullable: true));
            CreateIndex("dbo.Bookings", "VisitorID");
            AddForeignKey("dbo.Bookings", "VisitorID", "dbo.Visitors", "VisitorID", cascadeDelete: true);
            DropColumn("dbo.Bookings", "PackgeDetails_PackageID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "PackgeDetails_PackageID", c => c.Int());
            DropForeignKey("dbo.Bookings", "VisitorID", "dbo.Visitors");
            DropIndex("dbo.Bookings", new[] { "VisitorID" });
            AlterColumn("dbo.Bookings", "VisitorID", c => c.Int());
            DropColumn("dbo.Bookings", "PackageID");
            RenameColumn(table: "dbo.Bookings", name: "VisitorID", newName: "Visitor_VisitorID");
            CreateIndex("dbo.Bookings", "PackgeDetails_PackageID");
            CreateIndex("dbo.Bookings", "Visitor_VisitorID");
            AddForeignKey("dbo.Bookings", "Visitor_VisitorID", "dbo.Visitors", "VisitorID");
            AddForeignKey("dbo.Bookings", "PackgeDetails_PackageID", "dbo.Packages", "PackageID");
        }
    }
}
