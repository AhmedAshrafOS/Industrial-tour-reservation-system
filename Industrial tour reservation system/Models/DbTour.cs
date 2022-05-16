using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Industrial_tour_reservation_system.Models
{
    public class DbTour : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VisitorBooking>().HasKey(sc => new { sc.VisitorID, sc.PackageID });
        }
        public DbSet<Visitor> Visitors {get; set;}
        public DbSet<Admin> Admins { get; set;}
        public DbSet<Subject> Subjects { get; set;}
        public DbSet<Place> Places { get; set;}
        public DbSet<Package> Packages { get; set;}
        public DbSet<Booking> Bookings { get; set;}
        public DbSet<VisitorBooking> VisitorBookings { get; set; }
    }
}