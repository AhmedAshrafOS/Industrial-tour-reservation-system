using Industrial_tour_reservation_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Industrial_tour_reservation_system.ViewModels
{
    public class UserBookingView
    {
        public Visitor Visitor { get; set; }
        public Package Package { get; set; }
        public Booking View_Booking { get; set; }
        public VisitorBooking VisitorBooking { get; set; }
        public List<Package> Package_List { get; set; }
    }
}