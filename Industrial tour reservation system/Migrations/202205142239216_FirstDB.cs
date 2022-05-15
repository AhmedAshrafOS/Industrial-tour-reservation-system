namespace Industrial_tour_reservation_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        BookingName = c.String(nullable: false),
                        TotalCost = c.Single(nullable: false),
                        NumOfVistors = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        Hour = c.Int(nullable: false),
                        Minuit = c.Int(nullable: false),
                        VisitorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Visitors", t => t.VisitorID, cascadeDelete: true)
                .Index(t => t.VisitorID);
            
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        VisitorID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(nullable: false),
                        avatar = c.String(),
                    })
                .PrimaryKey(t => t.VisitorID);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        PackageID = c.Int(nullable: false, identity: true),
                        PackageName = c.String(nullable: false),
                        startLocation = c.String(nullable: false),
                        Transport = c.String(nullable: false),
                        CostForOne = c.Single(nullable: false),
                        Description = c.String(),
                        Min = c.Int(nullable: false),
                        Hour = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                        PlaceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PackageID)
                .ForeignKey("dbo.Places", t => t.PlaceID, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.SubjectID)
                .Index(t => t.PlaceID);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        PlaceID = c.Int(nullable: false, identity: true),
                        companyName = c.String(nullable: false),
                        Image = c.String(),
                        Country = c.String(nullable: false),
                        City = c.String(),
                        Street = c.String(),
                    })
                .PrimaryKey(t => t.PlaceID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Packages", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.Packages", "PlaceID", "dbo.Places");
            DropForeignKey("dbo.Bookings", "VisitorID", "dbo.Visitors");
            DropIndex("dbo.Packages", new[] { "PlaceID" });
            DropIndex("dbo.Packages", new[] { "SubjectID" });
            DropIndex("dbo.Bookings", new[] { "VisitorID" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Places");
            DropTable("dbo.Packages");
            DropTable("dbo.Visitors");
            DropTable("dbo.Bookings");
            DropTable("dbo.Admins");
        }
    }
}
