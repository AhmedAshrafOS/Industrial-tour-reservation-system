using Industrial_tour_reservation_system.Models;
using Industrial_tour_reservation_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Industrial_tour_reservation_system.Controllers
{
    public class AdminBookingController : Controller
    {
        // GET: AdminBooking
        private DbTour db = new DbTour();

        public ActionResult Index()
        {

            var Booked = db.Bookings.ToList();

            return View(Booked);
        }

        public ActionResult DetailsPackage(int id)
        {
            var Current_Booking = db.Bookings.Find(id);

            var Current_Package = db.Packages.SingleOrDefault(x => x.PackageName == Current_Booking.NameOfPackage);
            UserBookingView UserBookingView = new UserBookingView
            {
                View_Booking= Current_Booking,
                Package = Current_Package,
            };
            if (UserBookingView == null)
            {
                return HttpNotFound();
            }
            return View(UserBookingView);
        }


        public ActionResult DeleteBooking(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                var Current_Booking = db.Bookings.Find(id);


            if (Current_Booking == null)
                return HttpNotFound();

            return View(Current_Booking);
        }


        [HttpPost]
        public ActionResult DeleteBooking(Booking Current_Booking)
        {
            try
            {
                if (Current_Booking.BookingID == 0)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                

                Booking Deleted_Booking = db.Bookings.Find(Current_Booking.BookingID);
                var All_Booking = db.VisitorBookings.ToList();
                foreach (var item in All_Booking)
                {
                    if(item.PackageID== Deleted_Booking.PackageID && item.VisitorID== Deleted_Booking.VisitorID)
                    {
                        db.VisitorBookings.Remove(item);
                    }
                }

                if (Deleted_Booking == null)
                    return HttpNotFound();

                db.Bookings.Remove(Deleted_Booking);
                db.SaveChanges();
                return RedirectToAction("Index");


            }
            catch
            {
                return View();
            }
        }
    }
}
